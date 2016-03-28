using UnityEngine;
using System.Collections;

public class enogeeBlastScript : MonoBehaviour {

    private float attackCoolDown = .3f;
    private float attackTimer;
    private Animator anim;
    private float gutsUsed = 10.33f;
    private comboSystemClass keyWumboCombo = new comboSystemClass(new string[] { "Crouch", "Vertical", "Horizontal", "Light Punch" });
    private float comboReset;
    private bool completeWumboCombo = false;
    private bool enogeeBlast = false;
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


        if (keyWumboCombo.check() && !enogeeBlast)
        {

            Debug.Log("success");
            onlyAttack();
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
        StartCoroutine(delayAttack());
    }
    void animationCoolDown()
    {
        myRigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
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
        }
    }

    IEnumerator delayAttack()
    {

        yield return new WaitForSeconds(0);
        yield return new WaitForSeconds(0);
    }
}
