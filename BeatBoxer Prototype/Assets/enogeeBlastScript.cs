using UnityEngine;
using System.Collections;

public class enogeeBlastScript : MonoBehaviour {

    private float attackCoolDown = .5f;
    private float attackTimer;
    private Animator anim;
    private float gutsUsed;
    private comboSystemClass keyWumboCombo = new comboSystemClass(new string[] { "Crouch", "Vertical", "Horizontal", "Light Punch"});
    private float comboReset;
    private bool completeWumboCombo = false;
    public bool enogeeBlast = false;
    private bool noJab = false;
    public bool beatFlip;
    private comboSystemClass stopMadness;
    BeatBoxerScript beatBoxerStats;
    private Rigidbody2D myRigidBody;
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        beatBoxerStats = gameObject.GetComponent<BeatBoxerScript>();
        anim = gameObject.GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (beatBoxerStats.guts > (beatBoxerStats.maxGuts / 2) )       {
            if (keyWumboCombo.check() && !enogeeBlast)
            {

                //anim.SetBool("jabAttack", noJab);
                StartCoroutine(delayAttack());

            }
        }

        if (enogeeBlast)
        {
            
            SendMessageUpwards("inputFlag", true);
            animationCoolDown();
            anim.SetBool("shootBlast", enogeeBlast);

        }


    }


    void onlyAttack()
    {

        enogeeBlast = true;
        attackTimer = attackCoolDown;
       
    }
    void animationCoolDown()
    {
        myRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        if (attackTimer > 0)
        {

            attackTimer -= Time.deltaTime;
        }
        else
        {
            //beatBoxerStats.guts -= gutsUsed;
            //stopMadness = new comboSystemClass(false);
            myRigidBody.constraints = RigidbodyConstraints2D.None;
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            enogeeBlast = false;
            SendMessageUpwards("inputFlag", false);
            noJab = true;
            beatBoxerStats.guts -= (beatBoxerStats.maxGuts / 2);
        }
    }

    IEnumerator delayAttack()
    {

        yield return new WaitForSeconds(.2f);
        onlyAttack();
    }
}
