using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ObjectiveColider : MonoBehaviour
{

    public TMP_Text ObjectiveParent;
    public TMP_Text ObjectiveChildText1;
    public TMP_Text ObjectiveChildText2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ObjectiveParent.text = "Force you way through";
            ObjectiveChildText1.text = "DESTROY THE GATE";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ObjectiveParent.text = "Force you way through";
            ObjectiveChildText1.text = "Good Job";
            Destroy(gameObject);
        }
    }
}

