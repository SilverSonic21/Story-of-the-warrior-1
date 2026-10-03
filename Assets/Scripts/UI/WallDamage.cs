using UnityEngine;
using UnityEngine.UI;

public class WallDamage : MonoBehaviour
{
    public float maxHealth = 100f;
    public Slider wallHealthSlider;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;

        if (wallHealthSlider != null)
        {
            wallHealthSlider.maxValue = 1f;   // normalized slider
            wallHealthSlider.value = 1f;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (wallHealthSlider != null)
        {
            wallHealthSlider.value = currentHealth / maxHealth;
        }

        Debug.Log("Wall took damage: " + amount);

        if (currentHealth <= 0)
        {
            Die();
        }
        
    }

    void Die()
    {
        Destroy(gameObject);
    }
}


