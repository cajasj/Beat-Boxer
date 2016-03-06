using UnityEngine;
using System.Collections;
using System;

public class BeatBoxerScript : MonoBehaviour {
    public int health=40;
    public int strength = 1;
    public float maxSpeed = 10f;
    public float agility = 15f;
    bool facingRight = true;
    bool stop = true;
    public Vector3 playerPos;
    private Rigidbody2D myRigidBody;
    private Rigidbody2D myRigidBody2;
    int exp = 0;
    public float x;
    public float y;
    Animator animUpDown;
    Animator animCrouch;
    public bool flipping;
    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        animUpDown = GetComponent<Animator>();
        animCrouch = GetComponent<Animator>();
        flipping = false;
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
                animUpDown.SetFloat("walking", Mathf.Abs(x));
            }
            else
            {
                animUpDown.SetFloat("walking", Mathf.Abs(0));

            }

            if (Input.GetButton("Vertical"))
            {

                animUpDown.SetFloat("walking", Mathf.Abs(y));
            }

       

        ////////////////////////
        //////Crouch//////////
        //////////////////////
        if (Input.GetButton("Crouch"))
        {
            animCrouch.SetBool("crouch", true);
            stop = true;
            SendMessageUpwards("noInteruption", stop);
            myRigidBody.velocity = new Vector3(0 * maxSpeed, 0 * maxSpeed, myRigidBody.velocity.y);
        }
        else
        {
            stop = false;
            animCrouch.SetBool("crouch", false);
            SendMessageUpwards("noInteruption", stop);
        }
        /////////////////
        ////Running/////
        ///////////////
        if (Input.GetKey( KeyCode.LeftShift)&&(Input.GetButton("Horizontal")|| Input.GetButton("Vertical")))
        {
            animCrouch.SetBool("running", true);
            maxSpeed = agility;
        }
        else
        {
            animCrouch.SetBool("running", false);
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
   

}
