using UnityEngine;

public class SwordGuy : MonoBehaviour
{
    public Animator animator;
    public float damage = 6f;
    public float maxHealth = 20;
    public float currentHealth;
    public float damageToPlayer = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("The Enemy has taken damage.");
         DeathTracker tracker = GetComponent<DeathTracker>();
        if (tracker != null)
        {
            tracker.spawner.EnemyDied();
        }
        Destroy(gameObject);
    }
    
  private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        PlayerControler player = hit.collider.GetComponent<PlayerControler>();

        if (player != null)
        {
            player.TakeDamage(damageToPlayer);
        }
    }
}
