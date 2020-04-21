using UnityEngine;
using UnityEngine.UI;


public class ScoreBoard : MonoBehaviour
{


    int score;
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void ScoreHit(int scorePerHit)
    {    
        if (score >= 100)
        {
            score = score + scorePerHit*2;
            scoreText.text = score.ToString();
        }
        else
        {
            score = score + scorePerHit;
            scoreText.text = score.ToString();
        }
    }
}
