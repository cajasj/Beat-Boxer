using UnityEngine;
using System.Collections;

public class hulkSmashTrigger : MonoBehaviour {
    public int hulkSmashDamage = 30;
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
            col.SendMessageUpwards("beatBoxerHits", hulkSmashDamage);
        }
        col.isTrigger = false;
    }
}
