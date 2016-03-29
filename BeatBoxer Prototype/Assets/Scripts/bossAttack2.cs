using UnityEngine;
using System.Collections;

public class bossAttack2 : MonoBehaviour {

    private Animator anim;
    private bool hulkSmash = false;
    private bool touch;
    private float attackCoolDown = 1f;
    private float attackTimer = 0;
    //private bool noTrigger;
    private BeatBoxerScript beatBoxerStats;
    public Collider2D smashTrigger;
    private Rigidbody2D myRigidBody;
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        smashTrigger.enabled = false;
    }
    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreLayerCollision(13, 14, true);
    }

    // Update is called once per frame
    void Update()
    {

        if (touch && !hulkSmash)
        {
            hulkSmash = true;
            attackTimer = attackCoolDown;
            smashTrigger.enabled = true;
            SendMessageUpwards("stopBossAttack", hulkSmash);
        }
        if (smashTrigger.enabled == true)
        {
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (hulkSmash)
        {

            animationCoolDown();
            anim.SetBool("closeUp", hulkSmash);

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

            hulkSmash = false;
            SendMessageUpwards("stopBossAttack", hulkSmash);
            smashTrigger.enabled = false;
            myRigidBody.constraints = RigidbodyConstraints2D.None;
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
   
    void upPersonal(bool attackTouch)
    {
        touch = attackTouch;
    }
}
