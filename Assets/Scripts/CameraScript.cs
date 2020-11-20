using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;         //Getting the distance between the player's position and camera's position.

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.


    }
}