using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    #region Singleton

    private static ScoreManager _instance = null;

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: ScoreManager not Found");
                }
            }

            return _instance;
        }
    }

    #endregion


    public static int score;
    public static int highscore = 0;
    public Text text;
    public Text highScoreText = null;

    private void Start()
    {
        score = 0;

        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "9":
                highscore = PlayerPrefs.GetInt("highscore", highscore);
                break;
        }
        
    }

    public void SetHighScore(int curScore)
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            float highscore = PlayerPrefs.GetFloat("highscore");
            PlayerPrefs.SetFloat("highscore", curScore);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetFloat("highscore", curScore);
            PlayerPrefs.Save();
        }
        highscore = curScore;
        highScoreText.text = "High Score: " + highscore;
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "9":
                highScoreText.text = "High Score: " + highscore;
                if (score > highscore)
                {
                    highScoreText.text = "High Score: " + score;
                }
                break;
        }
        
        text.text = "Score: " + score;
        
    }
}
