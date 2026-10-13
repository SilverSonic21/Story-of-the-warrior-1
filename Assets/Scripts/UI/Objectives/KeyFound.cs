using UnityEngine;
using TMPro;

public class KeyFound : MonoBehaviour
{
    public TMP_Text ObjectiveParent;
    public TMP_Text ObjectiveChildText1;
    //public TMP_Text ObjectiveChildText2;
  
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory.hasKey = true;
            ObjectiveParent.text = "Key Found";
            ObjectiveChildText1.text = "Go to the Castle Gate";
            
        }
        Destroy();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
