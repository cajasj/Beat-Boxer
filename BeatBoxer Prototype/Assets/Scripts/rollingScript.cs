using UnityEngine;
using System.Collections;

public class rollingScript : MonoBehaviour {
    public BeatBoxerScript checkCrouch;
    private float rollCoolDown = 1f;
    private float rollTimer = 0;
    private bool rolling;
    private Animator anim;
    // Use this for initialization
    void Awake () {
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (checkCrouch.stop && !rolling)
        {
            Debug.Log(checkCrouch.stop);
            weRollin();
        }
        if (rolling)
        {
            animationCoolDown();
            anim.SetBool("roll", rolling);
        }
        




    }
    void weRollin()
    {
        if (Input.GetButton("Crouch")&& Input.GetButton("Horizontal"))
        {
            rolling = true;
            rollTimer = rollCoolDown;
            Debug.Log("And every time you see me I'm wet and I'm rolling Tunechi rest in peace, fresh to death and I'm rolling");
        }
    }
    void animationCoolDown()
    {
        if (rollTimer > 0)
        {

            rollTimer -= Time.deltaTime;
        }
        else
        {

            rolling = false;

        }
    }
}

