using TMPro;
using UnityEngine;

public class DefeatEnemy : MonoBehaviour
{
    public TMP_Text ObjectiveParent;
    public TMP_Text ObjectiveChildText1;
    public TMP_Text ObjectiveChildText2;

    private bool objectiveActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectiveActive = true;
            ObjectiveParent.text = "Take care of the enemy";
            ObjectiveChildText1.text = "0 / 20";

            GetComponent<Collider>().enabled = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Destroy(gameObject);
        }

    }

    public void UpdateCounter(int killed, int total)
    {
        if (!objectiveActive)
        {
           // Debug.Log("Objective is NOT active — ignoring update.");
            return;
        }

        ObjectiveChildText1.text = killed + " / " + total;

        if (killed >= total)
        {
            ObjectiveChildText1.text = "Good Job";
        }
    }
}
