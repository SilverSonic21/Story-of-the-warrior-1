using UnityEngine;

public class SwordGuy : MonoBehaviour
{
    public Animator animation;
    public float damage = 6f;
    public float maxHealth = 20;
    public float currentHeath;
    public float damageToPlayer = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHeath = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHeath -= amount;
        Debug.Log("The Enemy has taken damage.");
        if (currentHeath <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy has died.");
        Destroy(gameObject);
    }
    // Update is called once per frame
  private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        PlayerControler player = hit.collider.GetComponent<PlayerControler>();

        if (player != null)
        {
            player.TakeDamage(damageToPlayer);
        }
    }
}
