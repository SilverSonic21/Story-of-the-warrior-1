using UnityEngine;
using TMPro;

public class KeyFound : MonoBehaviour
{
    public TMP_Text ObjectiveParent;
    public TMP_Text ObjectiveChildText1;
    public TMP_Text ObjectiveChildText2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ObjectiveParent.text = "Key Found";
            ObjectiveChildText1.text = "You found the key";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ObjectiveParent.text = "Go to the Castle Gate";
            ObjectiveChildText1.text = "Open the gate";
            Destroy(gameObject);
        }
    }
}
