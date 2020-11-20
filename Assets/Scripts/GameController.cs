using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    public Text scoreLabel;
    public GameObject StartButton;
    private int _score;
    [Header("Storage")]
    public GameObject storage;
    public int Score
    {
        get
        {
            return _score;

        }
        set
        {
            _score = value;
            storage.GetComponent<Storage>().score = _score;
            scoreLabel.text = "Score : " + _score.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case ("Main"):
                Debug.Log("Start scene!");
                break;
            case ("Level1Scene"):
                Debug.Log("Level1 scene!");
                Score = 0;
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
