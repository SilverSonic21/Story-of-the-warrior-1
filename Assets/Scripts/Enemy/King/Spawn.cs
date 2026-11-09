using UnityEngine;
using TMPro;

public class Spawn : MonoBehaviour
{
     public TMP_Text ObjectiveParent;
    public TMP_Text ObjectiveChildText1;
    public TMP_Text ObjectiveChildText2;
    public GameObject king;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        king.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //objectiveActive = true;
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
        /*if (!objectiveActive)
        {
           // Debug.Log("Objective is NOT active — ignoring update.");
            return;
        }
        */

        ObjectiveChildText1.text = killed + " / " + total;

        if (killed >= total)
        {
            ObjectiveParent.text = "The King has appeared";
            ObjectiveChildText1.text = "!!!Defeat the King!!!";
            king.SetActive(true);
        }
    }
}
