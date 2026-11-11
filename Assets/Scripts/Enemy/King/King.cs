using UnityEngine;
using UnityEngine.UI;

public class King : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth = 60;
    private float currentHealth;
    public Slider kingHealthSlider;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip ebit;

    [Header("Damage")]
    public float damage = 6f;
    public float damageToPlayer = 10f;

    [Header("GameObjects")]
    public GameObject gate;
    public GameObject gate2;
    public GameObject winScreen;

    void Start()
    {
        currentHealth = maxHealth;
        if (kingHealthSlider != null)
        {
            kingHealthSlider.maxValue = 1f;   
            kingHealthSlider.value = 1f;
        }
        
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

        if (kingHealthSlider != null)
        {
            kingHealthSlider.value = currentHealth / maxHealth;
        }

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
        audioSource.PlayOneShot(ebit);
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
