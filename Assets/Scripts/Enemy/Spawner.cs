using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Spawner : MonoBehaviour
{
      public float spawnRadius = 10f;
     public Transform spawnCenter;
    [System.Serializable]
    public class SpawnableEnemy
    {
        public string name;
        public GameObject enemyPrefab;
        public int count;
        public float interval = 1f;
        public int pointValue;
        public float minDistance = 5f;
         
    }

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<SpawnableEnemy> enemiesInWave = new List<SpawnableEnemy>();
    }

    public List<Wave> waves = new List<Wave>();

    [Header("Random Spawn Area")]
    public Transform spawnPointA;
    public Transform spawnPointB;

    public float timeBetweenWaves = 5f;

    [Header("Win Condition")]
    public GameObject winScreen;

    private int currentWaveIndex = 0;
    private int enemiesAlive = 0;
    private bool allWavesSpawned = false;

    private Transform player;

    void Start()
    {
        if (winScreen != null)
            winScreen.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(RunWaves());
    }

    IEnumerator RunWaves()
    {
        while (currentWaveIndex < waves.Count)
        {
            Wave currentWave = waves[currentWaveIndex];

            Debug.Log("Starting Wave " + (currentWaveIndex + 1) + ": " + currentWave.waveName);

            yield return StartCoroutine(SpawnWaveRandomized(currentWave));

            currentWaveIndex++;

            yield return new WaitForSeconds(timeBetweenWaves);
        }

        allWavesSpawned = true;
        Debug.Log("All waves spawned.");
    }

    IEnumerator SpawnWaveRandomized(Wave wave)
    {
        List<SpawnableEnemy> spawnQueue = new List<SpawnableEnemy>();

        foreach (var enemy in wave.enemiesInWave)
        {
            for (int i = 0; i < enemy.count; i++)
            {
                spawnQueue.Add(enemy);
            }
        }

        Shuffle(spawnQueue);

        foreach (var enemy in spawnQueue)
        {
            SpawnEnemy(enemy);
            yield return new WaitForSeconds(enemy.interval);
        }
    }

    void SpawnEnemy(SpawnableEnemy enemyData)
    {
        Vector3 spawnPos = GetRandomSpawnPosition();

        int attempts = 0;

        while (Vector3.Distance(player.position, spawnPos) < enemyData.minDistance && attempts < 20)
        {
            spawnPos = GetRandomSpawnPosition();
            attempts++;
        }

        GameObject spawnedEnemy = Instantiate(enemyData.enemyPrefab, spawnPos, Quaternion.identity);

        enemiesAlive++;

        DeathTracker tracker = spawnedEnemy.AddComponent<DeathTracker>();
        tracker.spawner = this;
    }

    public void EnemyDied()
    {
        enemiesAlive--;
        Debug.Log("Enemies alive: " + enemiesAlive);

        if (allWavesSpawned && enemiesAlive <= 0)
        {
            //WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("YOU WIN!");

        if (winScreen != null){
            winScreen.SetActive(true);
        }
        Time.timeScale = 0f;
    }

    Vector3 GetRandomSpawnPosition()
    {
       if (!spawnCenter)
    {
        Debug.LogWarning("Spawn center must be assigned!");
        return Vector3.zero;
    }

    Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;

    // Keep enemies on ground (optional)
    randomOffset.y = 0f;

    return spawnCenter.position + randomOffset;
        
    }

    void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);

            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
