using UnityEngine;

public class King : MonoBehaviour
{
    public float damage = 6f;
    public float maxHealth = 20;
    public float currentHealth;
    public float damageToPlayer = 10f;
    public GameObject gate;
    public GameObject gate2;
    public GameObject winScreen;

    void Start()
    {
        currentHealth = maxHealth;
        gate2.SetActive(false);
        gate.SetActive(true);
        winScreen.SetActive(false);
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
           Die();

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

    public void Die()
    {
        Destroy(gameObject);
        //gate2.SetActive(true);
        //gate.SetActive(false);
        winScreen.SetActive(true);
        WinGame();

    }

    void WinGame()
    {
        Debug.Log("YOU WIN!");

        if (winScreen != null){
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Time.timeScale = 0f;
    }
}
