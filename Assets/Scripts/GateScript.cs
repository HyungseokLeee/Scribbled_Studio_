using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public Transform position1;
    public Transform position2;
    public Transform position3;
    public Transform position4;
    public Transform position5;
    public Transform position6;
    public Transform position7;
    public Transform position8;

    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Instantiate(wall, position1);
            Instantiate(wall, position2);
            Instantiate(wall, position3);
            Instantiate(wall, position4);
            Instantiate(wall, position5);
            Instantiate(wall, position6);
            Instantiate(wall, position7);
            Instantiate(wall, position8);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Bullet"))
        {
            Destroy(col.gameObject);
        }
    }
}
