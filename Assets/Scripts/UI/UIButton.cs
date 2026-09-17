using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
   
    public void OnPlayAgainButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void OnMainMenuButton()
    {
    SceneManager.LoadSceneAsync("MainMenu");    
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync("Play1");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
