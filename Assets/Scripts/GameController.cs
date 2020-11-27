using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject ExitButton;
    public Text titleLabel;
    public Text scoreLabel;
    public Text HighscoreLabel;
    public Text livesLabel;
    private int _score;
    private int _lives;
    private int startingLives;
    [Header("Game Setting")]
    public Storage storage;
    public int Score
    {
        get
        {
            return _score;

        }
        set
        {
            _score = value;
            //storage.GetComponent<Storage>().score = _score;
            scoreLabel.text = "Score : " + _score.ToString();
            if (storage.highscore < _score && SceneManager.GetActiveScene().name != "Tutorial")
            {
                storage.highscore = _score;
            }
            scoreLabel.text = "Score : " + storage.score.ToString();
        }
    }
    public int Lives
    {
        get
        {
            return _lives;
        }
        set
        {
            _lives = value;
            storage.lives = _lives;
            livesLabel.text = "Lives: " + _lives.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        HighscoreLabel.text = "High Score: " + storage.highscore;
        startingLives = 3;
        switch (SceneManager.GetActiveScene().name)
        {
            case ("Main"):
                Debug.Log("Start scene!");
                StartButton.SetActive(true);
                ExitButton.SetActive(true);
                titleLabel.enabled = true;
                scoreLabel.enabled = false;
                HighscoreLabel.enabled = false;
                livesLabel.enabled = false;
                break;
            case ("Level1Scene"):
                StartButton.SetActive(false);
                ExitButton.SetActive(false);
                titleLabel.enabled = false;
                scoreLabel.enabled = true;
                HighscoreLabel.enabled = true;
                livesLabel.enabled = true;

                Debug.Log("Level1 scene!");
                Score = 0;
                Lives = startingLives;
                break;
                
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Level1Scene");
        Debug.Log("Scene is changed to Level 1!");
    }
    public void OnExitButtonClick()
    {
        Debug.Log("Game is terminated!");
        Application.Quit();
    }
    public void scoreUp()
    {

    }
}
