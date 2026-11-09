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
        //Debug.Log("Enemy took damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {

            Destroy(gameObject);
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
