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
    public float maxGuts;
    public float gutSubRoll = 30f;
    public float regenAmount;
    private int force = 10;
    public float maxSpeed = 10f;
    bool facingRight = true;
    public bool stop = true;
    public bool rollInitiate = false;
    private BoxCollider2D offOn;
    public Vector3 playerPos;
    private Rigidbody2D myRigidBody;
    private Rigidbody2D myRigidBody2;
    private bool regenGutsOn=true;
    private bool rollOn;
    public float x;
    public float y;
    bool rollDrain = true;
    public int gutsRoll = 10;
    private float rollTimer;
    private float rollCooldown = .5f;
    Animator beatBoxerMovement;
    public bool flipping;
    public shop[] shoppingList;
    public enemyScript rollImmunity;
    public GameObject enemy;
    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        beatBoxerMovement = GetComponent<Animator>();
        enemy = GameObject.Find("enemyPlaceHolder");
        rollImmunity = enemy.GetComponent<enemyScript>();
        flipping = false;
        maxGuts = guts;
        offOn = GetComponent<BoxCollider2D>();
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
        if (guts<=maxGuts&& regenGutsOn)
        {
            regenAmount = ((float)endurance+4) / 10;
                guts += regenAmount * Time.deltaTime;
            if (guts > maxGuts)
            {
                guts = maxGuts;
            
            }
        }
        
        if (Input.GetButton("Crouch")) {
            
            beatBoxerMovement.SetBool("crouch", true);
            stop = true;
            rollOn = false;
            SendMessageUpwards("noInteruption", stop);
            //myRigidBody.velocity = new Vector3(0 * maxSpeed, 0 * maxSpeed, myRigidBody.velocity.y);
            if (Input.GetButton("Horizontal")==true&& rollInitiate ==false)

            {
                onlyRoll();
            }
            if (rollInitiate && guts>20)
            {
                rollOn = true;
                if (rollOn)
                {
                    beatBoxerMovement.SetBool("rolling", rollInitiate);

                    Physics2D.IgnoreLayerCollision(11, 12,true);
                    animationCoolDown();
                    
                    StartCoroutine("staminaDrain");
                   
                   // myRigidBody.AddForce(new Vector3(10, 0, 0), ForceMode2D.Impulse);
                    
                    
                }

            }
            else
            {
                
                myRigidBody.velocity = new Vector3(0 * maxSpeed, 0 * maxSpeed, myRigidBody.velocity.y);
                beatBoxerMovement.SetBool("rolling", false);
            }

        }
        else
        {
            Physics2D.IgnoreLayerCollision(11, 12, false);  
            regenGutsOn = true;
            beatBoxerMovement.SetBool("rolling", false);

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
    void onlyRoll()
    {
        rollInitiate = true;
        rollTimer = rollCooldown;
    }
    void animationCoolDown()
    {
        if (rollTimer > 0)
        {

            rollTimer -= Time.deltaTime;
        }
        else
        {

            rollInitiate = false;
            rollOn = false;
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
    IEnumerator staminaDrain()
    {
        if (rollDrain) {

            guts -= gutsRoll;
          
            rollDrain = false;
            yield return new WaitForSeconds(rollTimer);
            rollDrain = true;

        }


    }
    
}
