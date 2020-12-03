using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
	public String sceneName;

	public GameObject player;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == player.tag)
		{
			SceneManager.LoadScene(sceneName);
		}
	}

}
