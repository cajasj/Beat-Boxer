using UnityEngine;
using System.Collections;

public class moveBlast : MonoBehaviour {
    private float speed;
    public int blastDamage = 1;
    private Rigidbody2D myRigidbody;
    public BeatBoxerScript beatFlip;
    public GameObject beatBoxer;
    public blastScript direction;
    private Animator anim;
    //Animator movement;
    // Use this for initialization
    void Awake()
    {
        speed = 10f;
        beatBoxer = GameObject.Find("Player");
        beatFlip = beatBoxer.GetComponent<BeatBoxerScript>();
        direction = beatBoxer.GetComponent<blastScript>();
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (direction.firingBlast == true)
        {
            if (beatFlip.facingRight == false)
            {
                speed *= 1;
                //Debug.Log(speed);

            }
            if (beatFlip.facingRight == true)
            {
                speed *= -1;
                //Debug.Log(speed);
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }

        }
   
    }
    void Start () {
        beatFlip.myRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        //movement = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (beatFlip.mixtapeBool)
        {
            anim.SetBool("mixTapeSwitch", true);
            blastDamage = 2;
        }
        else
        {
            anim.SetBool("mixTapeSwitch", false);

        }
        myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
        if (transform.position.x > 14 || transform.position.x <-14)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject,3);
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "enemy")
        {
           
            col.gameObject.SendMessage("underAttack", blastDamage);
            Destroy(gameObject);
        }
       
    }

  
}
