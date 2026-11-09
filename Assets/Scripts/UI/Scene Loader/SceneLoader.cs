using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Castle";

    private bool loading = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !loading)
        {
            loading = true;

            Scene scene = SceneManager.GetSceneByName(nextSceneName);

            if (!scene.isLoaded)
            {
                SceneManager.LoadScene(nextSceneName, LoadSceneMode.Additive);
            }

            SceneManager.SetActiveScene(
                SceneManager.GetSceneByName(nextSceneName)
            );
        }
    }
}
