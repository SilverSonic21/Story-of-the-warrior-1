using UnityEngine;

public class DeathTracker : MonoBehaviour
{
    public Spawner spawner;

    void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.EnemyDied();
        }
    }
}
