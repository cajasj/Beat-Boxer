using UnityEngine;
using System.Collections;

public class hammerTimeScript : MonoBehaviour {
    private float attackCoolDown = .3f;
    private float attackTimer;
    private Animator anim;
    private float gutsUsed = 10.33f;
    private comboSystemClass keyWumboCombo = new comboSystemClass(new string[] { "Horizontal", "Horizontal", "Crouch", "Heavy Punch" });
    private float comboReset;
    private bool completeWumboCombo = false;
    private bool hammerTime = false;
    private comboSystemClass stopMadness;
    BeatBoxerScript beatBoxerStats;
    private Rigidbody2D myRigidBody;
    public Collider2D hammerTimeTrigger;
    private bool stayoff;

    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        hammerTimeTrigger.enabled = false;
        beatBoxerStats = gameObject.GetComponent<BeatBoxerScript>();
        anim = gameObject.GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (beatBoxerStats.guts > 30)
        {

            if (keyWumboCombo.check() && !hammerTime)
            {

                Debug.Log("success");
                onlyAttack();
                StartCoroutine(preventFlicker());
            }
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
        if (stayoff == false)
        {
            StartCoroutine(delayAttack());
            stayoff = true;
        }
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
            hammerTimeTrigger.enabled = false;
            myRigidBody.constraints = RigidbodyConstraints2D.None;
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            hammerTime = false;
        }
    }

    IEnumerator preventFlicker()
    {

        yield return new WaitForSeconds(1.1f);
        stayoff = false;
        hammerTimeTrigger.enabled = false;
    }
    IEnumerator delayAttack()
    {
        yield return new WaitForSeconds(.35f);

        hammerTimeTrigger.enabled = true;
        stayoff = true;

    }
}
