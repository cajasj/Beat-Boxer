using UnityEngine;
using System.Collections;
using System;

public class BeatBoxerScript : MonoBehaviour {

    public int maxHealth = 40;
    public int currentHealth;
    public int currentExp;
    public int currentMoney;
    public int strength = 20;
    public int endurance = 1;
    public int maxEnd;
    public int vitality = 10;
    public int maxVit;
    public float agility = 15f;
    public float guts;
    public float maxGuts = 100f;
    public float gutSubRoll = 30f;
    public float regenAmount;
    private int force = 10;
    public float maxSpeed = 10f;
    bool facingRight = true;
    public bool stop = true;
    public bool rollInitiate = false;
   // public BoxCollider2D offOn;
    public Vector3 playerPos;
    public Rigidbody2D myRigidBody;
    public float luda;
    public float cris;
    private float knockbackDuration = 1.3f;
    private float knockbackTimer = 0;
    private bool regenGutsOn = true;
    private bool rollOn;
    public float x;
    public float y;
    bool rollDrain = true;
    private int gutsRoll = 10;
    private float rollTimer;
    private float rollCooldown = .5f;
    public Animator beatBoxerMovement;
    public bool flipping;
    public shop[] shoppingList;
    public GameObject enemy;
    public afterDefeat beaten;
    public int combo2;
    public int combo3;
    public int mixtape;
    public hammerTimeScript hammerTime;
    public hammerTimeTrigger hammerTimeTrig;
    public enogeeBlastScript enogeeBlast;
    public blastScript enogeeAttack;
    public bossScript enemyObject;
    public GameObject boss;
    private bool knock = false;
    //public enogeeBlastScript enogeeBlast;
    //public enogeeBlastTrigger enogeeBlastTrig;
    // Use this for initialization
    void Start() {
        boss = GameObject.Find("Boss");
        enemyObject = boss.GetComponent<bossScript>();
        myRigidBody = GetComponent<Rigidbody2D>();
        beatBoxerMovement = GetComponent<Animator>();
        enemy = GameObject.Find("enemyPlaceHolder");
        maxEnd = endurance;
        maxVit = vitality;
        flipping = false;
        hammerTime = hammerTime.GetComponent<hammerTimeScript>();
        enogeeBlast = enogeeBlast.GetComponent<enogeeBlastScript>();
        enogeeAttack = enogeeAttack.GetComponent<blastScript>();
       // offOn = GetComponent<BoxCollider2D>();
        if (Application.loadedLevel == 1) {
            PlayerPrefs.DeleteAll();
            currentHealth = maxHealth;
            guts = maxGuts;
        }
        else
        {
            
            currentExp = PlayerPrefs.GetInt("exp");
            currentMoney = PlayerPrefs.GetInt("money");
            strength = PlayerPrefs.GetInt("strength");
            agility = PlayerPrefs.GetInt("agility");
            endurance = PlayerPrefs.GetInt("endurance");
            vitality = PlayerPrefs.GetInt("vitality");
            currentHealth = PlayerPrefs.GetInt("health");
            guts = PlayerPrefs.GetInt("guts");
            combo2 = PlayerPrefs.GetInt("combo2");
            combo3 = PlayerPrefs.GetInt("combo3");
            mixtape = PlayerPrefs.GetInt("mixtape");
        }

    }

    // Update is called once per frame
    void Update() {
        checkPurchase();
        ////////////////////
        ////X Y Movement///
        //////////////////  



        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        myRigidBody.velocity = new Vector3(x * maxSpeed, y * maxSpeed, myRigidBody.velocity.y);
        myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (currentHealth <= 0)
        {
            beatBoxerMovement.SetBool("noHealth", true);
            myRigidBody.velocity = new Vector3(0 * maxSpeed, 0 * maxSpeed, myRigidBody.velocity.y);
            beaten.youLose(true);
            //beatBoxerMovement.SetFloat("walking", Mathf.Abs(0));
        }
        else
        {
            beaten.youLose(false);
            beatBoxerMovement.SetBool("noHealth", false);
            myRigidBody.velocity = new Vector3(x * maxSpeed, y * maxSpeed, myRigidBody.velocity.y);
        }
        if (Input.GetButton("Horizontal"))
        {
            beatBoxerMovement.SetFloat("walking", Mathf.Abs(x));
        }
        else
        {
            beatBoxerMovement.SetFloat("walking", Mathf.Abs(0));

        }

        if (Input.GetButton("Vertical"))
        {

            beatBoxerMovement.SetFloat("walking", Mathf.Abs(y));
        }
        if (guts <= maxGuts && regenGutsOn)
        {
            regenAmount = ((float)endurance + 10) / 10;
            guts += regenAmount * Time.deltaTime;
            if (guts > maxGuts)
            {
                guts = maxGuts;

            }
        }

        if (Input.GetButton("Crouch")) {
            beatBoxerMovement.SetFloat("walking", Mathf.Abs(0));
            beatBoxerMovement.SetBool("crouch", true);
            stop = true;
            rollOn = false;
            SendMessageUpwards("noInteruption", stop);

            //myRigidBody.velocity = new Vector3(0 * maxSpeed, 0 * maxSpeed, myRigidBody.velocity.y);
            if (Input.GetButton("Horizontal") && !rollInitiate)

            {

                onlyRoll();
            }
            if (rollInitiate && guts >= gutsRoll)
            {
                rollOn = true;
                if (rollOn)
                {
                    beatBoxerMovement.SetBool("rolling", true);

                    Physics2D.IgnoreLayerCollision(11, 12, true);


                    StartCoroutine("staminaDrain");

                    // myRigidBody.AddForce(new Vector3(10, 0, 0), ForceMode2D.Impulse);


                }
            } else
            {


                myRigidBody.velocity = new Vector3(0 * maxSpeed, 0 * maxSpeed, myRigidBody.velocity.y);
                beatBoxerMovement.SetBool("rolling", false);
            }

        }
        else
        {
            Physics2D.IgnoreLayerCollision(11, 12, false);
            regenGutsOn = true;
            //rollOn = false;
            rollInitiate = false;
            beatBoxerMovement.SetBool("rolling", false);

            stop = false;
            beatBoxerMovement.SetBool("crouch", false);
            SendMessageUpwards("noInteruption", stop);
        }

        if (vitality > maxVit)
        {
            newMaxHealth();
        }
        if (endurance > maxEnd)
        {
            newMaxGuts();
        }

        /////////////////
        ////Running/////
        ///////////////
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetButton("Horizontal") || Input.GetButton("Vertical")))
        {
            beatBoxerMovement.SetBool("running", true);
            maxSpeed = agility;
        }
        else
        {
            beatBoxerMovement.SetBool("running", false);
            maxSpeed = 10f;
        }
        ////////////////////
        /////Flip Sprite///
        //////////////////
        if (x > 0 && !facingRight)
        {
            flipping = false;
            Flip();

        }
        else if (x < 0 && facingRight)
        {
            flipping = true;
            Flip();

        }
    }
    void onlyRoll()
    {
        rollInitiate = true;
        rollTimer = rollCooldown;
    }
    void animationCoolDown()
    {
        if (rollTimer > 0)
        {

            rollTimer -= Time.deltaTime;
        }
        else
        {

            rollInitiate = false;

        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    public void awardEXP(int enemyEXP)
    {
        currentExp += enemyEXP;
        Debug.Log(currentExp);
    }
    public void awardMoney(int enemyMoney)
    {
        currentMoney += enemyMoney;
        Debug.Log(currentMoney);
    }
    public void beatBoxerHits(int getHit)
    {
        currentHealth -= getHit;

    }
    public void newMaxGuts()
    {
        maxGuts += 10;
        guts = maxGuts;
        maxEnd = endurance;
    }
    public void newMaxHealth()
    {
        maxHealth += 20;
        maxVit = vitality;
        currentHealth = maxHealth;
    }
    //public void beatBoxerKnockBack(float ludacrisGetBack)
    //{
    //    luda = ludacrisGetBack;
    //    cris = 0f;
    //    knockBackSetting();
    //    if (enemyObject.flipper == false)
    //    {
    //        myRigidBody.AddForce(new Vector3(-124, cris, 0), ForceMode2D.Impulse);
    //        Debug.Log("in the luada code");

    //    }
    //    else
    //    {
    //        myRigidBody.AddForce(new Vector3(-124, cris, 0), ForceMode2D.Impulse);
    //    }

    //}
    //public void knockBackSetting()
    //{
    //    offOn.enabled = false;
    //    knockbackTimer = knockbackDuration;
    //    myRigidBody.isKinematic = false;
    //    knock = true;
   
    //}
    IEnumerator staminaDrain()
    {
        if (rollDrain) {
            animationCoolDown();
            guts -= gutsRoll;
            
            rollDrain = false;
            yield return new WaitForSeconds((float).5);
            rollDrain = true;

        }


    }
    public void checkPurchase()
    {
        if (combo2==1)
        {
            hammerTime.enabled = true;
            hammerTimeTrig.enabled = true;
        }
        else
        {
            hammerTimeTrig.enabled = false;
            hammerTime.enabled = false;
        }
        if (combo3 == 1)
        {
            enogeeBlast.enabled = true;
            enogeeAttack.enabled = true;
        }
        else
        {
            enogeeBlast.enabled = false;
            enogeeAttack.enabled = false;
        }
        if (mixtape == 1)
        {

        }
    }
}
