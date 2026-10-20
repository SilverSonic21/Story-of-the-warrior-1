using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreen;

    void Start()
    {
        winScreen.SetActive(false);
    }

    public void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
            ShowWinScreen();
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
        StartCoroutine(DelayInput());
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    IEnumerator DelayInput()
    {
  
        EventSystem.current.SetSelectedGameObject(null);


        yield return new WaitForSecondsRealtime(0.15f);

   
    }
}
