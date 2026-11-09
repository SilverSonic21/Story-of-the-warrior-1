using TMPro;
using UnityEngine;

public class DefeatEnemy2 : MonoBehaviour
{
    public TMP_Text ObjectiveParent;
    public TMP_Text ObjectiveChildText1;
    public TMP_Text ObjectiveChildText2;

    [Header("Boss")]
    public GameObject king;
    
    private bool objectiveActive = false;

    void Start()
    {
         if (king != null)
        king.SetActive(false);

    }

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


    public void UpdateCounter(int killed, int total)
    {
        Debug.Log("UpdateCounter called");

        if (!objectiveActive)
        {
            Debug.Log("Objective not active!");
            return;
        }

        ObjectiveChildText1.text = killed + " / " + total;

        if (killed >= total)
        {
            ObjectiveParent.text = "The King Has Appear";
            ObjectiveChildText1.text = "!!!Defeat THe King!!!";
            if (king != null)
            {
                king.SetActive(true);
            }
        }
    }
}
