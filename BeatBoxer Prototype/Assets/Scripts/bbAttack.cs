using UnityEngine;
using System.Collections;

public class bbAttack : MonoBehaviour
{
    private bool jabAttack = false;
    private float attackCoolDown=.3f;
    private float attackTimer=0;
    private bool disableInput = false;
    private bool noTrigger;
    public Collider2D jabTrigger;
    private Animator anim;
    private BeatBoxerScript test;
    GameObject work;
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        jabTrigger.enabled = false;
    }
    // Use this for initialization
    void Start()
    {
        test = GetComponent<BeatBoxerScript>();
        
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("j") && !jabAttack )
        {
            if ((noTrigger==false)&&
               (Input.GetButton("Horizontal") == false ^ Input.GetButton("Vertical")) )
            {
                jabAttack = true;
                attackTimer = attackCoolDown;
                jabTrigger.enabled = true;
            }
        }
        if (jabAttack)
        {
            if (attackTimer > 0)
            {
               
                attackTimer -= Time.deltaTime;
            }
            else
            {
               
                jabAttack = false;
                jabTrigger.enabled = false;
            }
        }
       
        anim.SetBool("jabAttack", jabAttack);
    }
    public void noInteruption(bool stop)
    {
        noTrigger = stop;
    }
}
