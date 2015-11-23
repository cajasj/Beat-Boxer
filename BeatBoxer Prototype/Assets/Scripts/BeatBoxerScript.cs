using UnityEngine;
using System.Collections;

public class BeatBoxerScript : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;
    public Vector3 playerPos;
    private Rigidbody2D myRigidBody;
    private Rigidbody2D myRigidBody2;
    Animator animx;
    Animator animy;
	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        animx = GetComponent<Animator>();
        animy = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");

        float y = Input.GetAxis("Vertical");
        animx.SetFloat("walking", Mathf.Abs(x));
        //animy.SetFloat("walking", Mathf.Abs(y));
        myRigidBody.velocity = new Vector3(x * maxSpeed, y*maxSpeed, myRigidBody.velocity.y);
        
        if (x >0 && !facingRight)
        {
            Flip();
        }else if(x <0 && facingRight)
        {
            Flip();
        }
	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
