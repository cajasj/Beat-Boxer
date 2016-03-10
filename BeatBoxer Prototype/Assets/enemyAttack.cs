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
    public Collider2D swipeTrigger;
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        swipeTrigger.enabled = false;

    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(swipe);
        if (touch && !swipe)
        {
            swipe = true;
            attackTimer = attackCoolDown;
            swipeTrigger.enabled = true;
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

        }
    }
    void touching(bool attackTouch)
    {
        touch = attackTouch;
    }
}
