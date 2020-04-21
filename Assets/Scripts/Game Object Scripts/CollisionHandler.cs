using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{

    [Tooltip("In time")][SerializeField] float loadLevelDelay = 1f;
    [Tooltip("FX prefab on death")] [SerializeField] GameObject deathFX;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        print("Player collided  smth");
    }

    private void OnTriggerEnter(Collider other)
    {
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
