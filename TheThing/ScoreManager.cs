using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;

    public float scoreCount = 0.0f;
    public float hiScoreCount = 0.0f;

    public float pointsPerSecond;

    public bool scoreIncreassing = true;

    void Start()
    {
        float highscore = PlayerPrefs.GetFloat("highscore"); //read
    }

    void Update()
    {
        

        if (scoreIncreassing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("highscore", hiScoreCount); //save
        }

        scoreText.text = "Score: " + Mathf.Round (scoreCount);
        highscoreText.text = "Highscore: " + Mathf.Round (hiScoreCount);
    }
}
