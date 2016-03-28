using UnityEngine;
using System.Collections;

public class moveBlast : MonoBehaviour {
    public float speed = 8f;
    private Rigidbody2D myRigidbody;
    //Animator movement;
	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        //movement = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        myRigidbody.velocity = new Vector2(speed,myRigidbody.velocity.y);
        if (transform.position.x > 16)
        {
            Destroy(gameObject);
        }
    }
   
}
