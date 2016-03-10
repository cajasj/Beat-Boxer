using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {
    private bool knock = false;
    private float knockbackDuration = .3f;
    private float knockbackTimer = 0;
    public int currHealth;
    public int maxHealth;
    private Rigidbody2D enemeyRigidBody;
    public BeatBoxerScript enemyObject;
    public GameObject beatBoxer;
    float speed;
    public int enemyEXP;
    public int enemyMoney;
    private float Range = 15f;
    public float luda;
    public float cris;
    public Transform enemyMoving;
    public Transform target;
    private BoxCollider2D offOn;
    bool flipper=false;
    bool attack;
    float xDiag = 50f;
    float yDiag = 24f;
    // Use this for initialization
    void Start () {
        enemeyRigidBody = GetComponent<Rigidbody2D>();
        enemeyRigidBody.isKinematic = true;
        currHealth = maxHealth;
        beatBoxer = GameObject.Find("Player");
        enemyObject = beatBoxer.GetComponent<BeatBoxerScript>();
        speed = 3f;
        enemyMoving = beatBoxer.transform;
        offOn = GetComponent<BoxCollider2D>();
    }
    
    // Update is called once per frame
    void Update ()
    {
       
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
          
            }
        }
        checkHealth();
       
        if (transform.position.x < enemyMoving.position.x && flipper == false)
        {
            
            Flip();
            flipper = true;
        }

        if (transform.position.x > enemyMoving.position.x && flipper == true)
        {

            Flip();
            flipper = false;
        }

        if (Vector3.Distance(enemyMoving.position, transform.position) < Range&& attack ==true)
        {
            move();
        }
        ////////
        if (Vector3.Distance(enemyMoving.position, transform.position)<2.2)
        {
            attack = false;
        }
        else
        {
            attack = true;
        }
    }
  
    public void move()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, enemyMoving.position, step);
      
        
    }
   
    public void underAttack(int damage)
    {
       
        currHealth -= damage;

    }
   
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
    void checkHealth()
    {
        if (currHealth <= 0)
        {
            attack = false;
            enemeyRigidBody.isKinematic = false;
            offOn.enabled = false;
            transform.Rotate(0, 0, Time.deltaTime * 3000);
            luda = 30;
            cris = 24;
            Object.Destroy(gameObject, .5f);
           
                
        }
        
    }
    public void knockBackSetting()
    {
        offOn.enabled = false;
        knockbackTimer = knockbackDuration;
        enemeyRigidBody.isKinematic = false;
        checkHealth();
        knock = true;
        if (currHealth <= 0)
        {
            knockbackTimer = 1f;

            enemyObject.awardEXP(enemyEXP);
            enemyObject.awardMoney(enemyMoney);
        }
    }
    void Flip()
    {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        
    }
}
