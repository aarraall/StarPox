using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
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
