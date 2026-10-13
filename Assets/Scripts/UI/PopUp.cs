using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PopUp : MonoBehaviour
{
    public GameObject Gate;

    public GameObject popup;
    public TMP_Text ObjectiveParent;
    public TMP_Text ObjectiveChildText1;
    private bool playerInside = false;
    public GameObject needKeyWindow;
    public TMP_Text needKeyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       popup.SetActive(false); 
    }
    void Update()
    {
         if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            OpenGate();
        }
    }

    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            popup.SetActive(true);
            playerInside = true;
        }
        
    }

      void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            popup.SetActive(false);
            playerInside = false;
            needKeyWindow.SetActive(false);
        }
    }

    void OpenGate()
    {
    if (PlayerInventory.hasKey)
        {
            Destroy(Gate);
            Destroy(popup);
            needKeyWindow.SetActive(false);
        }
        else
        {
            needKeyWindow.SetActive(true);
            needKeyText.text = "You need a key!";
        }
    }
}
