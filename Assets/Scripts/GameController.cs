using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;

public class GameController : MonoBehaviour
{   
    public GameObject StartButton;
    public GameObject ExitButton;
    public GameObject RetryButton;
    public Text titleLabel;
    public Text scoreLabel;
    public Text HighscoreLabel;
    public Text livesLabel;
    public int _score;
    public int _lives;
    private int _HP;
    public int _firerateLev;
    public int startingLives;
    public bool key;
    public AudioSource audioSource;
    [Header("Game Setting")]
    public Storage storage;
    private HpBarController hpBarController;
    public int Score
    {
        get
        {
            return _score;

        }
        set
        {
            _score = value;
            storage.score = _score;
            scoreLabel.text = "Score : " + _score.ToString();
            if (storage.highscore < _score && SceneManager.GetActiveScene().name != "Tutorial")
            {
                storage.highscore = _score;
            }
            scoreLabel.text = "Score : " + storage.score.ToString();
            HighscoreLabel.text = "High Score: " + storage.highscore;
        }
    }
    public int HP
    {

        get
        {
            return _HP;
        }
        set
        {
            _HP = value;
            //hpLabel.text = "HP: " + _HP.ToString();
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
    public int FirerateLev
    {
        get
        {
            return _firerateLev;
        }
        set
        {
            _firerateLev = value;
            storage.fireRateLev = _firerateLev;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
        GameObject hpO = GameObject.FindWithTag("HpStatus");
        hpBarController = hpO.GetComponent<HpBarController>();
        
        startingLives = 3;
        switch (SceneManager.GetActiveScene().name)
        {
            case ("Main"):
                Debug.Log("Start scene!");
                StartButton.SetActive(true);
                ExitButton.SetActive(true);
                titleLabel.gameObject.SetActive(true);
                scoreLabel.gameObject.SetActive(false);
                HighscoreLabel.gameObject.SetActive(false);
                livesLabel.gameObject.SetActive(false);
                break;
            case ("Level1Scene"):
                StartButton.SetActive(false);
                ExitButton.SetActive(false);
                titleLabel.gameObject.SetActive(false);
                scoreLabel.gameObject.SetActive(true);
                HighscoreLabel.gameObject.SetActive(true);
                livesLabel.gameObject.SetActive(true);

                Debug.Log("Level1 scene!");
                Score = storage.score;
                Lives = startingLives;
                audioSource = GetComponent<AudioSource>();
                break;
            case ("Level2Scene"):
                StartButton.SetActive(false);
                ExitButton.SetActive(false);
                titleLabel.gameObject.SetActive(false);
                scoreLabel.gameObject.SetActive(true);
                HighscoreLabel.gameObject.SetActive(true);
                livesLabel.gameObject.SetActive(true);

                Debug.Log("Level1 scene!");
                Score = storage.score;
                Lives = storage.lives;
                audioSource = GetComponent<AudioSource>();
                break;
            case ("Level3Scene"):
                StartButton.SetActive(false);
                ExitButton.SetActive(false);
                titleLabel.gameObject.SetActive(false);
                scoreLabel.gameObject.SetActive(true);
                HighscoreLabel.gameObject.SetActive(true);
                livesLabel.gameObject.SetActive(true);

                Debug.Log("Level1 scene!");
                Score = storage.score;
                Lives = storage.lives;
                audioSource = GetComponent<AudioSource>();
                break;

            case ("Test_Scene"):
                StartButton.SetActive(false);
                ExitButton.SetActive(false);
                titleLabel.gameObject.SetActive(false);
                scoreLabel.gameObject.SetActive(true);
                HighscoreLabel.gameObject.SetActive(true);
                livesLabel.gameObject.SetActive(true);

                Debug.Log("Test scene!");
                Score = storage.score;
                Lives = startingLives;
                break;
            case ("GameOver_Scene"):
                Score = storage.score;
                Lives = storage.lives;
                hpBarController.health = 0.0f;
                StartButton.SetActive(false);
                RetryButton.SetActive(true);
                ExitButton.SetActive(true);
                titleLabel.gameObject.SetActive(false);
                scoreLabel.gameObject.SetActive(true);
                HighscoreLabel.gameObject.SetActive(true);
                livesLabel.gameObject.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Lives < 0)
        {

        }
        //Test//
        if(Input.GetKeyDown(KeyCode.T))
        {
            hpBarController.SetDamage(20.0f);
        }
    }

    public void PlayAudio(AudioClip sound)
    {
	    audioSource.clip = sound;
	    audioSource.Play();
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Level1Scene");
        Debug.Log("Scene is changed to Level 1!");
        resetStorage();
    }
    public void OnExitButtonClick()
    {
        Debug.Log("Game is terminated!");
        Application.Quit();
    }
    public void scoreUp(int score)
    {
        Score += score;
        Debug.Log(Score);
    }
    public void addFirerateLev(int num)
    {
        FirerateLev += 1;
    }
    public void resetStorage()
    {
        storage.score = 0;
        storage.lives = startingLives;
        storage.fireRateLev = 0;
        
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver_Scene");
    }
}
