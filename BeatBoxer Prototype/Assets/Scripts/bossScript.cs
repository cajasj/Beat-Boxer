﻿using UnityEngine;
using System.Collections;

public class bossScript : MonoBehaviour {

    

    public int currHealth;
    public int maxHealth;
    private Rigidbody2D enemeyRigidBody;
    public BeatBoxerScript enemyObject;
    public GameObject beatBoxer;
    public Animator anim;
    float speed;
    private float Range = 50f;
 
    public Transform enemyMoving;
    public Transform target;
    public BoxCollider2D offOn;
    bool flipper = false;
    public bool attack;
    public bool attack2;
    public bool getHit;
    private bool stopit;

    // Use this for initialization
    void Start()
    {
        Flip();
        enemeyRigidBody = GetComponent<Rigidbody2D>();
        enemeyRigidBody.isKinematic = true;
        currHealth = maxHealth;
        beatBoxer = GameObject.Find("Player");
        anim =  GetComponent<Animator>();
        enemyObject = beatBoxer.GetComponent<BeatBoxerScript>();
        speed = 5f;
        enemyMoving = beatBoxer.transform;
        offOn = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

      
        //////////////////////////////////
        ////Function to change force/////
        ////when hp ==0/////////////////
        ///////////////////////////////
        checkHealth();


        /////////////////////////
        /////////AI/////////////
        ///////////////////////
        if (transform.position.x < enemyMoving.position.x && flipper == false)
        {
            if (!stopit)
            {
                Flip();
                flipper = true;
            }
        }

        if (transform.position.x > enemyMoving.position.x && flipper == true)
        {
            if (!attack||!attack2)
            {
                Flip();
                flipper = false;
            }
        }
        //sDebug.Log("attack is " + attack);
        if (Vector3.Distance(enemyMoving.position, transform.position) < Range && Vector3.Distance(enemyMoving.position, transform.position) > 2.3)
        {
            if (currHealth > 0 && !stopit)
            {
                move();
            }
        }
        if (Vector3.Distance(enemyMoving.position, transform.position) <= 2.3 && Vector3.Distance(enemyMoving.position, transform.position) >= 2.1)
        {
            SendMessageUpwards("upPersonal", false);
            attack = true;
            SendMessageUpwards("touchBoss", attack);
            Debug.Log("up close");

        } else
        {
            attack = false;
            SendMessageUpwards("touchBoss", attack);
        }
        if (Vector3.Distance(enemyMoving.position, transform.position) <= 2.1)
        {
            attack2 = true;
            Debug.Log(Vector3.Distance(enemyMoving.position, transform.position));
            SendMessageUpwards("upPersonal", attack2);
            Debug.Log("up personal");

        }
        else
        {
            attack2 = false;
            SendMessageUpwards("upPersonal", attack2);
        }
    }

    /////////////////////////////
    ////////AI////////////////// 
    ///////////////////////////
    public void move()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, enemyMoving.position, step);
        transform.Rotate(0, 0, 0);

    }

    /////////////////////////////
    ////////Damage Recieve////// 
    ///////////////////////////
    public void underAttack(int damage)
    {

        currHealth -= damage;
        getHit = true;
        SendMessageUpwards("weHit", false);
    }

    
    
    void checkHealth()
    {
        if (currHealth <= 0)
        {
            anim.SetBool("dead", true);
            Object.Destroy(gameObject, 1.6f);


        }
      

    }
    void stopBossAttack(bool stopMe)
    {
        stopit = stopMe;
    }
    
    /////////////////////////////
    ////////Flip Sprite///////// 
    ///////////////////////////

    void Flip()
    {

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}