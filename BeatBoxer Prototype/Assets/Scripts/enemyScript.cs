using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {
    public int currHealth;
    public int maxHealth=30;
	// Use this for initialization
	void Start () {
        currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void attacking(int damage)
    {
        currHealth -= damage;
        Debug.Log(currHealth);
        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
   
}
