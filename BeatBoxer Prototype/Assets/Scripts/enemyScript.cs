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
    public Transform enemyMoving;
    public Transform target;
    private BoxCollider2D offOn;
    bool flipper=false;
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
        if (currHealth <= 0)
        {

            Destroy(gameObject);
            enemyObject.awardEXP(enemyEXP);
            enemyObject.awardMoney(enemyMoney);
            
        }

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

        if (Vector3.Distance(enemyMoving.position, transform.position) < Range)
        {
            move();
        }
        enemyMoving.LookAt(target);
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
        knockBackSetting();
        
        if (enemyObject.flipping == false)
        {

            enemeyRigidBody.AddForce(Vector3.right * ludacrisGetBack);
        }
        else
        {

            enemeyRigidBody.AddForce(Vector3.left * ludacrisGetBack);

        }
        
    }
    public void knockMeDown(float ludacrisGetBack)
    {
        knockBackSetting();
        enemeyRigidBody.AddForce(Vector3.down * ludacrisGetBack);
      
       
    }
    public void knockBackSetting()
    {
        offOn.enabled = false;
        knock = true;
        knockbackTimer = knockbackDuration;
        enemeyRigidBody.isKinematic = false;
    }
    void Flip()
    {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        
    }
}
