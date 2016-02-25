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
    float range;
     private GameObject Player;
    private GameObject Enemies;
    private float Range;
    public Collider2D stopMoving;
    // Use this for initialization
    void Start () {
        enemeyRigidBody = GetComponent<Rigidbody2D>();
        enemeyRigidBody.isKinematic = true;
        currHealth = maxHealth;
        Debug.Log(currHealth);
        knockOut = GameObject.Find("Player");
        knockbackFlag = knockOut.GetComponent<BeatBoxerScript>();
        speed = .5f;
        Player = GameObject.FindGameObjectWithTag("Player");
        Enemies = GameObject.FindGameObjectWithTag("enemy");
        
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
        if (stopMoving.CompareTag("Player")){
            Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * speed, (transform.position.y - Player.transform.position.y) * speed);
            enemeyRigidBody.velocity = -velocity;
        }
    }
    

    public void underAttack(int damage)
    {
       
        currHealth -= damage;
        Debug.Log(currHealth);

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("jabbing"))
        {
            knock = true;
            knockbackTimer = knockbackDuration;
            enemeyRigidBody.isKinematic = false;
            Debug.Log(knockbackFlag.flipping);
            if (knockbackFlag.flipping == false)
            {

                Debug.Log(knockbackFlag.flipping);
                enemeyRigidBody.AddForce(Vector3.right * 100);
            } else
            {

                Debug.Log(knockbackFlag.flipping);
                enemeyRigidBody.AddForce(Vector3.left * 100);

            }
        }
        
       
    }
   
}
