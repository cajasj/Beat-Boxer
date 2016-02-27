using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {
    public GameObject spawnMe;
    // Use this for initialization
	void Start () {
        // invoke("spawning");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void spawning()
    {
        GameObject anEnemy = (GameObject)Instantiate(spawnMe);
        //anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }
}
