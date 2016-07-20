using UnityEngine;
using System.Collections;

public class hammerTime : MonoBehaviour {

    private float attackCoolDown = .3f;
    private float attackTimer;
    private Animator anim;
    private float gutsUsed = 3.33f;
    private comboSystemClass keyWumboCombo = new comboSystemClass(new string[] { "Horizontal", "Horizontal", "Crouch", "Heavy Punch" });
    private float comboReset;
    private bool completeWumboCombo = false;
    private bool hammerTime = false;
    private comboSystemClass stopMadness;
    BeatBoxerScript beatBoxerStats;
    private Rigidbody2D myRigidBody;
    public Collider2D upperCutTrigger;
    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        upperCutTrigger.enabled = false;
        beatBoxerStats = gameObject.GetComponent<BeatBoxerScript>();
        anim = gameObject.GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (keyWumboCombo.check() && !hammerTime)
        {

            Debug.Log("success");
            onlyAttack();
        }


        if (hammerTime)
        {

            animationCoolDown();
            anim.SetBool("hammerTime", hammerTime);

        }


    }


    void onlyAttack()
    {

        hammerTime = true;
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
            beatBoxerStats.guts -= gutsUsed;
            //stopMadness = new comboSystemClass(false);
            upperCutTrigger.enabled = false;
            myRigidBody.constraints = RigidbodyConstraints2D.None;
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            hammerTime = false;
        }
    }

    IEnumerator delayAttack()
    {

        yield return new WaitForSeconds(1);
        upperCutTrigger.enabled = true;
        yield return new WaitForSeconds(0);
        upperCutTrigger.enabled = false;
    }
}
