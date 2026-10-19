using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
     private int nextSceneToLoad;
    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider player)
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
