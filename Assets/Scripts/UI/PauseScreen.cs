using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool isPaused = false;

    void Start()
    {
        pauseScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                Pause();
            else
                Resume();
        }
    }

    void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }

    void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }
}
