using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {
    private bool knock = false;
    private float knockbackDuration = .7f;
    private float knockbackTimer = 0;

    public int currHealth;
    public int maxHealth;
    private Rigidbody2D enemeyRigidBody;
    public BeatBoxerScript enemyObject;
    public GameObject beatBoxer;
    float speed;
    public int enemyEXP;
    public int enemyMoney=10;
    private float Range = 400f;
    public float luda;
    public float cris;
    public Transform enemyMoving;
    public Transform target;
    public BoxCollider2D offOn;
    bool flipper=false;
    public bool attack;
    public bool getHit;
    private bool stopit;
    // Use this for initialization
    void Start () {
        Physics2D.IgnoreLayerCollision(12 , 12, true);

        enemeyRigidBody = GetComponent<Rigidbody2D>();
        enemeyRigidBody.isKinematic = true;
        currHealth = maxHealth;
        beatBoxer = GameObject.Find("Player");
        enemyObject = beatBoxer.GetComponent<BeatBoxerScript>();
        speed = Random.Range(1f,4f);
        enemyMoving = beatBoxer.transform;
        offOn = GetComponent<BoxCollider2D>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        
       //////////////////////////
       ///////KnockBack/////////
       ////////////////////////
        if (knock)
        {
            if (knockbackTimer > 0)
            {
                knockbackTimer -= Time.deltaTime;
            }
            else
            {
                knock = false;
                enemeyRigidBody.isKinematic = true;
                offOn.enabled = true;
                //getHit = false;
            }
        }
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
            if (!attack)
            {
                Flip();
                flipper = false;
            }
        }
             //sDebug.Log("attack is " + attack);
        if (Vector3.Distance(enemyMoving.position, transform.position) < Range && Vector3.Distance(enemyMoving.position, transform.position)>1.5)
        {
            if (currHealth>0&& !stopit) { 
                move();
            }
        }
        if (Vector3.Distance(enemyMoving.position, transform.position)<=1.5)
        {
            attack = true;
            SendMessageUpwards("touching", attack);
            
        }
        else
        {
            attack = false;
            SendMessageUpwards("touching", attack);
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
        SendMessageUpwards("weHit",false);
    }

    /////////////////////////////
    ////////Knock Back X//////// 
    ///////////////////////////
    public void knockMeBack(float ludacrisGetBack)
    {
        luda = ludacrisGetBack;
        cris = 0f;
        knockBackSetting();
        
        if (enemyObject.flipping == false)
        {
            enemeyRigidBody.AddForce(new Vector3(luda, cris, 0), ForceMode2D.Impulse);
            
            
        }
        else
        {
            enemeyRigidBody.AddForce(new Vector3(-luda, cris, 0), ForceMode2D.Impulse);
        }
        
    }

    /////////////////////////////
    ///Knock Back Y///////////// 
    ///////////////////////////
    public void knockMeDown(float ludacrisGetBack)
    {
        luda = 0f;
        cris = ludacrisGetBack;
        knockBackSetting();
        if (enemyObject.flipping == false)
        {
            enemeyRigidBody.AddForce(new Vector3(luda, -cris, 0), ForceMode2D.Impulse);
        }
        else
        {
            enemeyRigidBody.AddForce(new Vector3(-luda, -cris, 0), ForceMode2D.Impulse);
        }
       
    }
    public void knockMeUp(float ludacrisGetBack)
    {
        luda = 0f;
        cris = ludacrisGetBack;
        knockBackSetting();
        if (enemyObject.flipping == false)
        {
            enemeyRigidBody.AddForce(new Vector3(luda, cris, 0), ForceMode2D.Impulse);
        }
        else
        {
            enemeyRigidBody.AddForce(new Vector3(-luda, -cris, 0), ForceMode2D.Impulse);
        }

    }
    /////////////////////////////
    ///Knocks Back Diagonally///
    ///////////////////////////
    void checkHealth()
    {
        if (currHealth <= 0)
        {
            attack = false;
            enemeyRigidBody.isKinematic = false;
            offOn.enabled = false;
            transform.Rotate(0, 0, Time.deltaTime * 1100);
            luda = 30;
            cris = 24;
            Object.Destroy(gameObject, 1.6f);


        }
        else
        {
            enemeyRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
    }
    void stopAttack(bool stopMe)
    {
        stopit = stopMe;
    }
    /////////////////////////////
    ///Change Object Property/// 
    /// when knocked back//////
    //////////////////////////
    public void knockBackSetting()
    {
        offOn.enabled = false;
        knockbackTimer = knockbackDuration;
        enemeyRigidBody.isKinematic = false;
        checkHealth();
        knock = true;
        /////////////////////////
        //////Award Once////////
        ///////////////////////
        if (currHealth <= 0)
        {
            knockbackTimer = 1.5f; /// make sure enemy object is off screen;
            enemyObject.awardEXP(enemyEXP);
            enemyObject.awardMoney(enemyMoney);
        }
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
