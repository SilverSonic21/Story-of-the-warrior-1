using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathUI;

    void Start()
    {
        if (deathUI != null)
            deathUI.SetActive(false);
    }

    public void ShowDeathScreen()
    {
        if (deathUI != null)
            deathUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }
}
