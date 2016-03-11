using UnityEngine;
using System.Collections;
using System;

public class BeatBoxerScript : MonoBehaviour {
    public int currentHealth=40;
    public int currentExp = 0;
    public int currentMoney = 0;
    public int strength = 1;
    public int endurance = 1;
    public int vitality = 10;
    public float agility = 15f;
    public float guts = 100f;
    private int force = 10;
    public float maxSpeed = 10f;
    bool facingRight = true;
    public bool stop = true;

    public Vector3 playerPos;
    private Rigidbody2D myRigidBody;
    private Rigidbody2D myRigidBody2;

    public float x;
    public float y;
    Animator beatBoxerMovement;
    public bool flipping;
    public shop[] shoppingList;
    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        beatBoxerMovement = GetComponent<Animator>();
        flipping = false;
    }
	void FixedUpdate()
    {

        ////////////////////////
        //////Crouch//////////
        //////////////////////
        //if (Input.GetButton("Crouch"))
        //{
        //    beatBoxerMovement.SetBool("crouch", true);
        //    stop = true;
        //    SendMessageUpwards("noInteruption", stop);
        //    myRigidBody.velocity = new Vector3(0 * maxSpeed, 0 * maxSpeed, myRigidBody.velocity.y);

        //}
        //else
        //{
        //    stop = false;
        //    beatBoxerMovement.SetBool("crouch", false);
        //    SendMessageUpwards("noInteruption", stop);
        //}

    }
    // Update is called once per frame
    void Update () {
        ////////////////////
        ////X Y Movement///
        //////////////////  
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        myRigidBody.velocity = new Vector3(x * maxSpeed, y * maxSpeed, myRigidBody.velocity.y);
      
            if (Input.GetButton("Horizontal"))
            {
                beatBoxerMovement.SetFloat("walking", Mathf.Abs(x));
            }
            else
            {
                beatBoxerMovement.SetFloat("walking", Mathf.Abs(0));

            }

            if (Input.GetButton("Vertical"))
            {

                beatBoxerMovement.SetFloat("walking", Mathf.Abs(y));
            }

        if (Input.GetButton("Crouch")) {
            
            beatBoxerMovement.SetBool("crouch", true);
            stop = true;
            SendMessageUpwards("noInteruption", stop);
            myRigidBody.velocity = new Vector3(0 * maxSpeed, 0 * maxSpeed, myRigidBody.velocity.y);
            if (Input.GetButton("Horizontal"))

            {

                beatBoxerMovement.SetBool("rolling", true);
                myRigidBody.AddForce(new Vector3(10, 0, 0), ForceMode2D.Impulse);
            }
            else
            {
                //myRigidBody.AddForce(new Vector3(1, 0, 0), ForceMode2D.Impulse);
                beatBoxerMovement.SetBool("rolling", false);
            }
        }
        else
        {
            stop = false;
            beatBoxerMovement.SetBool("crouch", false);
            SendMessageUpwards("noInteruption", stop);
        }
               

        /////////////////
        ////Running/////
        ///////////////
        if (Input.GetKey( KeyCode.LeftShift)&&(Input.GetButton("Horizontal")|| Input.GetButton("Vertical")))
        {
            beatBoxerMovement.SetBool("running", true);
            maxSpeed = agility;
        }
        else
        {
            beatBoxerMovement.SetBool("running", false);
            maxSpeed = 10f;
        }
       ////////////////////
       /////Flip Sprite///
       //////////////////
        if (x >0 && !facingRight)
        {
            flipping = false;
            Flip();
            
        }
        else if(x <0 && facingRight)
        {
            flipping = true;
            Flip();
            
        }
	}

    
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        
    }
   public void awardEXP(int enemyEXP)
    {
        currentExp += enemyEXP;
        Debug.Log(currentExp);
    }
    public void awardMoney(int enemyMoney)
    {
        currentMoney += enemyMoney;
        Debug.Log(currentMoney);
    }
}
