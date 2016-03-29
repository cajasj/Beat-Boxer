using UnityEngine;
using System.Collections;

public class moveBlast : MonoBehaviour {
    private float speed;
    public int blastDamage = 1;
    private Rigidbody2D myRigidbody;
    public BeatBoxerScript beatFlip;
    public GameObject beatBoxer;
    public blastScript direction;
    
    //Animator movement;
    // Use this for initialization
    void Start () {
        beatBoxer = GameObject.Find("Player");
        beatFlip = beatBoxer.GetComponent<BeatBoxerScript>();
        direction = beatBoxer.GetComponent<blastScript>();
        myRigidbody = GetComponent<Rigidbody2D>();
        //movement = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
       if (direction.firingBlast == true) { 
            if (beatFlip.facingRight==false)
            {
                speed = 8f;
            }
            if(beatFlip.facingRight==true)
            {
                speed = -10f;
            }
        }
      
        myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
        if (transform.position.x > 16 || transform.position.x <-14)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject,3);
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "enemy")
        {
           
            col.gameObject.SendMessage("underAttack", blastDamage);
            Destroy(gameObject);
        }
       
    }
  
  
}
