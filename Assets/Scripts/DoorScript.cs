using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
	public String sceneName;
    private GameController gC;
	public GameObject player;
	// Start is called before the first frame update
	void Start()
	{
        GameObject gCO = GameObject.FindWithTag("GameController");
        gC = gCO.GetComponent<GameController>();
    }

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == player.tag & gC.key == true)
        {
            gC.key = false;
			SceneManager.LoadScene(sceneName);
		}
	}

}
