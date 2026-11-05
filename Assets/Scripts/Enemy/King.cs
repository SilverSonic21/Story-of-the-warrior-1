using UnityEngine;

public class King : MonoBehaviour
{
    public float damage = 6f;
    public float maxHealth = 20;
    public float currentHealth;
    public float damageToPlayer = 10f;
    public GameObject gate;
    public GameObject gate2;

    void Start()
    {
        currentHealth = maxHealth;
        gate2.SetActive(false);
        gate.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Enemy took damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            DeathTracker tracker = GetComponent<DeathTracker>();

            if (tracker != null && tracker.spawner != null)
            {
                tracker.spawner.EnemyDied();
            }
            else
            {
                //Debug.LogWarning("DeathTracker or spawner missing — enemy will still die.");
            }

            Destroy(gameObject);
            gate2.SetActive(true);
            gate.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerControler player = other.GetComponent<PlayerControler>();

        if (player != null)
        {
            player.TakeDamage(damageToPlayer);
            //Debug.Log("Enemy damaged the player!");
        }
    }
}
