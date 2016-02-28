using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {
    private bool knock = false;
    private float knockbackDuration = .3f;
    private float knockbackTimer = 0;
    public int currHealth;
    public int maxHealth=30;
    private Rigidbody2D enemeyRigidBody;
    public BeatBoxerScript knockbackFlag;
    public GameObject knockOut;
    float speed;
    private GameObject Player;
    private float Range = 15f;
    public Transform enemyMoving;
    BeatBoxerScript forceBack;
    // Use this for initialization
    void Start () {
        enemeyRigidBody = GetComponent<Rigidbody2D>();
        enemeyRigidBody.isKinematic = true;
        currHealth = maxHealth;
        knockOut = GameObject.Find("Player");
        knockbackFlag = knockOut.GetComponent<BeatBoxerScript>();
        speed = 3f;
        Player = GameObject.FindGameObjectWithTag("Player");
        enemyMoving = Player.transform;
        
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
            }
        }
        if (currHealth <= 0)
        {

            Destroy(gameObject);
        }
        if (Vector3.Distance(enemyMoving.position, transform.position) < Range)
        {
            move();
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
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("jabbing"))
        {
            knockBackSetting();
            Debug.Log(knockbackFlag.flipping);
            if (knockbackFlag.flipping == false)
            {
                
                enemeyRigidBody.AddForce(Vector3.right * 1000);
            } else
            {
                
                enemeyRigidBody.AddForce(Vector3.left * 1000);

            }
        }
        if (col.CompareTag("benza"))
        {
            knockBackSetting();
            Debug.Log(knockbackFlag.flipping);
            if (knockbackFlag.flipping == false)
            {

                enemeyRigidBody.AddForce(Vector3.right * 2000);
            }
            else
            {
                
                enemeyRigidBody.AddForce(Vector3.left * 2000);

            }
        }
        if (col.CompareTag("hook"))
        {
            knockBackSetting();
            enemeyRigidBody.AddForce(Vector3.down * 1000);
           
        }

    }
   
    public void knockBackSetting()
    {
        knock = true;
        knockbackTimer = knockbackDuration;
        enemeyRigidBody.isKinematic = false;
    }
}
