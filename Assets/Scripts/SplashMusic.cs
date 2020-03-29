using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashMusic : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", 9f);
    }
    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
