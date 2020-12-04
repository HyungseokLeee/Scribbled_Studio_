using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private GameController gC;

    public Transform position1;
    public Transform position2;

    public GameObject enemy;

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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Getting Key!");
            Destroy(this.gameObject);
            gC.key = true;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, position1);
        Instantiate(enemy, position2);
    }
}
