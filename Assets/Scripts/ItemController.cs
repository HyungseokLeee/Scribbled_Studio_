﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private GameController gC;
    private PlayerMovement player;
    private AudioSource gem;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gCO = GameObject.FindWithTag("GameController");
        gC = gCO.GetComponent<GameController>();
        GameObject pO = GameObject.FindWithTag("Player");
        player = pO.GetComponent<PlayerMovement>();
        gem = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && this.gameObject.tag == "Treasure")
        {
            gem.Play();
            Debug.Log("Getting Treasure!");
            Destroy(this.gameObject, 1);
            gC.Score += 100;
        }
        if (col.gameObject.tag == "Player" && this.gameObject.tag == "Firerate_Reducer")
        {
            Debug.Log("Getting firerate_reducer!");
            Destroy(this.gameObject);
            if(gC.FirerateLev < 2)
            {
                player.reduceFirerate();
            }
            else
            {
                gC.scoreUp(200);
            }
        }
        if(col.gameObject.tag == "Player" && this.gameObject.tag == "HP_UP")
        {
            Debug.Log("Getting HP_UP");
            Destroy(this.gameObject);
        }
    }
}
