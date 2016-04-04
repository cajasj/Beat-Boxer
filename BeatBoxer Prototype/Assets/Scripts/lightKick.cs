using UnityEngine;
using System.Collections;

public class lightKick : MonoBehaviour {

    private bool jabAttack = false;
    private float attackCoolDown = .3f;
    private float attackTimer = 0;
    private bool noTrigger;
    public Collider2D lightKickTrig;
    private Animator anim;
    private Rigidbody2D myRigidBody;
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        lightKickTrig.enabled = false;
    }
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetKeyDown("l") && !jabAttack)
        {
            onlyAttack();
        }
        if (jabAttack)
        {
            animationCoolDown();
            anim.SetBool("lightKick", jabAttack);
        }


    }
    void onlyAttack()
    {
        if ((noTrigger == false) &&
               (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical")))
        {
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            jabAttack = true;
            attackTimer = attackCoolDown;
            lightKickTrig.enabled = true;
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

            jabAttack = false;
            lightKickTrig.enabled = false;
            myRigidBody.constraints = RigidbodyConstraints2D.None;
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    public void noInteruption(bool stop)
    {
        noTrigger = stop;
    }
}
