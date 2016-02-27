using UnityEngine;
using System.Collections;

public class uppercutAttack : MonoBehaviour {
    // Use this for initialization
    public float timeInBetweeen = .5f;
    private int lightPunchCounter = 0;
    private bool crouch;
    private bool hook;
    private float lastInput = 0;
    private bool jabAttack = false;
    private float attackCoolDown = .2f;
    private float attackTimer = 0;
    private bool disableInput = false;
    private bool noTrigger;
    public Collider2D hookTrigger;
    private Animator anim;
    void Start () {
        combo();
	}
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        hookTrigger.enabled = false;
    }
    void combo()
    {
        if (Input.GetKeyUp("j"))
        {
            lightPunchCounter++;
            lastInput = Time.time;
        }
        if (Input.GetButton("Crouch"))
        {
            crouch = true;
            lastInput = Time.time;
        }
        if (Input.GetKeyUp("i"))
        {
            hook = true;
            lastInput = Time.time;
        }
        if((lightPunchCounter==3 &&hook==true && crouch == true)||Time.time > (lastInput + timeInBetweeen))
        {
            onlyAttack();
        }
        
    }
	// Update is called once per frame
	void Update () {
        combo();
        if (jabAttack)
        {
            animationCoolDown();
            anim.SetBool("uppercut", jabAttack);
        }
    }
    void onlyAttack()
    {
        if ((noTrigger == false) &&
              (Input.GetButton("Horizontal") == false ^ Input.GetButton("Vertical")))
        {
            jabAttack = true;
            attackTimer = attackCoolDown;
            hookTrigger.enabled = true;
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
            hookTrigger.enabled = false;
        }
    }
    public void noInteruption(bool stop)
    {
        noTrigger = stop;
    }
}
