﻿using UnityEngine;
using System.Collections;

public class bossAttack1 : MonoBehaviour {

    private Animator anim;
    private bool smash = false;
    private bool touch;
    private float attackCoolDown = 1f;
    private float attackTimer = 0;
    //private bool noTrigger;
    public GameObject beatBoxer;
    public GameObject bossAttackSwitch;
    public Collider2D smashTrigger;
    private Rigidbody2D myRigidBody;
    public Transform bossPos;
    public Transform boxerPos;


    void Awake()
    {
        beatBoxer=GameObject.Find("Player");
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        smashTrigger.enabled = false;
        boxerPos = beatBoxer.transform;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (touch && !smash)
        {
            smash = true;
            attackTimer = attackCoolDown;
            smashTrigger.enabled = true;
            SendMessageUpwards("stopBossAttack", smash);
        }
        if (smashTrigger.enabled == true)
        {
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (smash)
        {

            animationCoolDown();
            anim.SetBool("far", smash);

        }

    }
    void animationCoolDown()
    {
        if (attackTimer > 0)
        {

            attackTimer -= Time.deltaTime;
        }
        else
        {

            smash = false;
            SendMessageUpwards("stopBossAttack", smash);
            smashTrigger.enabled = false;
            myRigidBody.constraints = RigidbodyConstraints2D.None;
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
 
    void touchBoss(bool attackTouch)
    {
        touch = attackTouch;
    }
}