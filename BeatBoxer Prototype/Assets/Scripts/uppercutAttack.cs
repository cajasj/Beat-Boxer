using UnityEngine;
using System.Collections;

public class uppercutAttack : MonoBehaviour
{
    // Use this for initialization
    public float timeInBetweeen = .8f;
    int i;
    private float attackCoolDown = .3f;
    private float attackTimer;
    private Animator anim;
    private float gutsUsed=10f;
    private string[] keyWumboCombo = { "J", "J", "J", "I", "Space" };
    public KeyCode[] wumboCombo;
    private float comboReset;
    private bool completeWumboCombo = false;
    private bool upperCut = false;
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
        wumboCombo = new KeyCode[keyWumboCombo.Length];
        for (int k = 0; k < keyWumboCombo.Length; k++)
        {
            wumboCombo[k] = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyWumboCombo[k]);
            
        }
    }
    void combo()
    {
    }
    // Update is called once per frame
    void Update()
    {
        resetTimer();
        detectButton();
        if (completeWumboCombo && !upperCut)
        {
            upperCut = true;
            attackTimer = attackCoolDown;
        }
        if (upperCut)
        {
            anim.SetBool("crouch", false);
            animationCoolDown();
            
            anim.SetBool("uppercut", upperCut);
            completeWumboCombo = false;

        }


    }
    void detectButton()
    {
        foreach (KeyCode mahKeys in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(mahKeys))
            {

                if (i < wumboCombo.Length && Input.GetKeyDown(mahKeys) == Input.GetKeyDown(wumboCombo[i]))
                {

                    //Debug.Log("key pressed "+ mahKeys+" counter "+i);
                    i++;
                    comboReset = .8f;

                }
                else
                {
                    i = 0;
                    //Debug.Log("messed up the combo you pressed " + mahKeys);

                }
                if (i >= wumboCombo.Length)
                {
                    i = 0;
                   // Debug.Log("complete sequence of button press");
                    if (beatBoxerStats.guts >= gutsUsed)
                    {
                        completeWumboCombo = true;

                        beatBoxerStats.guts -= gutsUsed;
                    }
                }

            }

        }

    }
    void resetTimer()
    {
        if (comboReset > 0)
        {
            comboReset -= Time.deltaTime;
        }
        else
        {
            i = 0;
        }
    }
    void onlyAttack()
    {
        
        upperCut = true;
        attackTimer = attackCoolDown;
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

            myRigidBody.constraints = RigidbodyConstraints2D.None;
            myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            upperCut = false;
        }
    }


}