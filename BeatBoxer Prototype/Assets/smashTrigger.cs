using UnityEngine;
using System.Collections;

public class smashTrigger : MonoBehaviour {
    public int smashDamage = 15;
    public static float ludacris = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.isTrigger == false && col.CompareTag("Player"))
        {
            col.isTrigger = true;
            col.SendMessageUpwards("beatBoxerHits", smashDamage);
            col.SendMessageUpwards("beatBoxerKnockBack", ludacris);
        }
        col.isTrigger = false;
    }
}

