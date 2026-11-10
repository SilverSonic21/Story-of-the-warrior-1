using TMPro;
using UnityEngine;

public class DefeatEnemy : MonoBehaviour
{
    public TMP_Text ObjectiveParent;
    public TMP_Text ObjectiveChildText1;
    public TMP_Text ObjectiveChildText2;
    public GameObject key;

    [Header ("Sound")]
    public AudioSource audioSource;
    public AudioClip keyAppear;
  

    private bool objectiveActive = false;

    void Start()
    {
        key.SetActive(false);
        audioSource = GetComponent<AudioSource>();
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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Destroy(gameObject);
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
            ObjectiveParent.text = "Find a way into the castle";
            ObjectiveChildText1.text = "Find the Key";
            key.SetActive(true);
            audioSource.PlayOneShot(keyAppear);

        }
    }
}