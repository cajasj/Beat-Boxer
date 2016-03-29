﻿using UnityEngine;
using System.Collections;

public class swipeTrigger : MonoBehaviour {
    private int  swipeDamage=5;
	// Use this for initialization
	void Start () {
        Physics2D.IgnoreLayerCollision(13, 14, true);

    }

    // Update is called once per frame
    void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.isTrigger == false && col.CompareTag("Player"))
        {
            col.isTrigger = true;
            col.SendMessageUpwards("beatBoxerHits",swipeDamage);
        }
        col.isTrigger = false;
    }
}
