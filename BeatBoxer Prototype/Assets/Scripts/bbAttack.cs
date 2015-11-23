using UnityEngine;
using System.Collections;

public class bbAttack : MonoBehaviour
{
    private bool jabAttack = false;
    private float attackCoolDown=.3f;
    private float attackTimer=0;
    public Collider2D jabTrigger;
    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        jabTrigger.enabled = false;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("j") && !jabAttack)
        {
           
            jabAttack = true;
            attackTimer = attackCoolDown;
            jabTrigger.enabled = true;
        }
        if (jabAttack)
        {
            if (attackTimer > 0)
            {
               
                attackTimer -= Time.deltaTime;
                //Debug.Log(attackTimer);
            }
            else
            {
               
                jabAttack = false;
                jabTrigger.enabled = false;
            }
        }
        anim.SetBool("jabAttack", jabAttack);
    }
}
