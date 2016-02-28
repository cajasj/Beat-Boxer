using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {
    public GameObject enemy ;

// Variable to know how fast we should create new enemies
public float  spawnTime = 2f;
    public float spawnCount = 0;

void Start()
    {
        // Call the 'addEnemy' function every 'spawnTime' seconds
       
            InvokeRepeating("addEnemy", spawnTime, spawnTime);
            
        
    }

    // New function to spawn an enemy
    void addEnemy()
    {
        // Variables to store the X position of the spawn object
        // See image below
        if (spawnCount < 10)
        {
            var x1 = transform.position.x - GetComponent<Renderer>().bounds.size.x / 2;
            var x2 = transform.position.x + GetComponent<Renderer>().bounds.size.x / 2;

            // Randomly pick a point within the spawn object
            var spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);
            spawnCount++;
            Debug.Log(spawnCount);
            // Create an enemy at the 'spawnPoint' position
            Instantiate(enemy, spawnPoint, Quaternion.identity);
        }
    }
}
