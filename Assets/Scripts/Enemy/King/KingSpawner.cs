using UnityEngine;
using TMPro;

public class Spawn : MonoBehaviour
{
    [Header("Enemy Settings")]
    public int totalEnemies = 20;
    private int enemiesKilled = 0;


    [Header("UI")]
    public DefeatEnemy2 objectiveUI2;

    private void Start()
    {
       
        if (objectiveUI2 != null)
        {
            objectiveUI2.UpdateCounter(0, totalEnemies);
        }
    }

    public void EnemyDied()
    {
        enemiesKilled++;

        Debug.Log($"Enemies Killed: {enemiesKilled}/{totalEnemies}");

        /*if (objectiveUI2 != null)
        {
            objectiveUI2.UpdateCounter(enemiesKilled, totalEnemies);
        }
        */
        if (enemiesKilled >= totalEnemies)
        {
            SpawnKing();
        }
    }

    private void SpawnKing()
    {
        Debug.Log("The King Has Appeared!");

        if (objectiveUI2 != null)
        {
            objectiveUI2.ObjectiveParent.text = "The King has appeared!";
            objectiveUI2.ObjectiveChildText1.text = "Defeat the King!";
        }

      
    }
}