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
    // Use this for initialization
    void Start () {
        enemeyRigidBody = GetComponent<Rigidbody2D>();
        enemeyRigidBody.isKinematic = true;
        currHealth = maxHealth;
        Debug.Log(currHealth);
        knockOut = GameObject.Find("Player");
        knockbackFlag = knockOut.GetComponent<BeatBoxerScript>();
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
