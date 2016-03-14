using UnityEngine;
using System.Collections;

public class enemyAttack : MonoBehaviour {
    private Animator anim;
    private bool swipe = false;
    private bool touch;
    private float attackCoolDown = .3f;
    private float attackTimer = 0;
    //private bool noTrigger;
    enemyScript test;
    private BeatBoxerScript beatBoxerStats;
    public Collider2D swipeTrigger;
    private Rigidbody2D myRigidBody;
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        swipeTrigger.enabled = false;
        test = gameObject.GetComponent<enemyScript>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (touch && !swipe)
        {
            swipe = true;
            attackTimer = attackCoolDown;
            swipeTrigger.enabled = true;
        }
        if(swipeTrigger.enabled == true)
        {
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (swipe)
        {
            
            animationCoolDown();
            anim.SetBool("touchPlayer", swipe);
            
        }
       
    }
    void animationCoolDown()
    {
        if (attackTimer > 0)
        {

            attackTimer -= Time.deltaTime;
        }
        else
        {

            swipe = false;
            swipeTrigger.enabled = false;
            myRigidBody.constraints = RigidbodyConstraints2D.None;
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    void weHit(bool noAttck)
    {
        swipe = noAttck;
    }
    void touching(bool attackTouch)
    {
        touch = attackTouch;
    }
}
