using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In time")][SerializeField] float loadLevelDelay = 2f;
    [Tooltip("FX prefab on death")] [SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        print("Player triggered with smth");
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", loadLevelDelay);
    }

    void StartDeathSequence()
    {
        print("Player dying");
        SendMessage("OnPlayerDeath");
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
