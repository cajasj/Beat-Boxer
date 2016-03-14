using UnityEngine;
using System.Collections;
/// <summary>
/// 
/// Add revelant scripts to each stage
/// 
/// 
/// </summary>
public class benzaAttack : MonoBehaviour {

    private bool jabAttack = false;
    private float attackCoolDown = .3f;
    private float attackTimer = 0;
    private bool noTrigger;
    public Collider2D benzaTrigger;
    private Animator anim;
    private Rigidbody2D myRigidBody;
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        benzaTrigger.enabled = false;
    }
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetKeyDown("k") && !jabAttack)
        {
            onlyAttack();
        }
        if (jabAttack)
        {
            animationCoolDown();
            anim.SetBool("benza", jabAttack);
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
            benzaTrigger.enabled = true;
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
            benzaTrigger.enabled = false;
            myRigidBody.constraints = RigidbodyConstraints2D.None;
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    public void noInteruption(bool stop)
    {
        noTrigger = stop;
    }
}
