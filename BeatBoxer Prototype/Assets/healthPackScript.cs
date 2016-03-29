using UnityEngine;
using System.Collections;

public class healthPackScript : MonoBehaviour {
    public BeatBoxerScript beatBoxerHealth;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.name == "Player")
        {
            beatBoxerHealth.currentHealth = beatBoxerHealth.maxHealth;
            beatBoxerHealth.guts = beatBoxerHealth.maxGuts;
            Destroy(gameObject);
        }
    }
}
