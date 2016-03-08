using UnityEngine;
using System.Collections;

public class removeFloatDam : MonoBehaviour {
    float damRemove = 1;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        damRemove -= Time.deltaTime;
        if (damRemove < 0)
        {
            Destroy(gameObject);
        }
	}
}
