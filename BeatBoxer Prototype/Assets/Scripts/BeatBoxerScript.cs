using UnityEngine;
using System.Collections;
using System;

public class BeatBoxerScript : MonoBehaviour {

    public float maxSpeed = 5f;
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
    public bool flipping = true;
    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        animUpDown = GetComponent<Animator>();
        animCrouch = GetComponent<Animator>();
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
        
        if(Input.GetButton("Vertical"))
        {

            animUpDown.SetFloat("walking", Mathf.Abs(y));
        }
        


        ////////////////////////
        //////Crouche//////////
        //////////////////////
        if (Input.GetButton("Crouch"))
        {
            animCrouch.SetBool("crouch", true);
            stop = true;
            SendMessageUpwards("noInteruption", stop);

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
        if (Input.GetKey( KeyCode.LeftShift))
        {
            animCrouch.SetBool("running", true);
        }
        else
        {
            animCrouch.SetBool("running", false);

        }
       ////////////////////
       /////Flip Sprite///
       //////////////////
        if (x >0 && !facingRight)
        {
            Flip();
            flipping = false;
            Debug.Log(flipping);
        }
        else if(x <0 && facingRight)
        {
            Flip();
            flipping = true;
            Debug.Log(flipping);
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
