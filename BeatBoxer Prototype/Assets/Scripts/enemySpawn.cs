using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {
    public GameObject enemy ;

// Variable to know how fast we should create new enemies
     float  spawnTime = 1f;
    public float spawnCount = 0;
    public Renderer rend;
    void Start()
    {
        // Ceall the 'addEnemy' function every 'spawnTime' seconds
        rend = GetComponent<Renderer>();
        InvokeRepeating("addEnemy", spawnTime, spawnTime);
            
        
    }

    // New function to spawn an enemy
    void addEnemy()
    {
        // Variables to store the X position of the spawn object
        // See image below
        if (spawnCount < 10)
        {
            float y1 = transform.position.y + rend.bounds.size.y;
            float y2 = transform.position.y- rend.bounds.size.y ;
            y1 -= 3;
            y2 += 3;

            // Randomly pick a point within the spawn object
            var spawnPoint = new Vector2(transform.position.x, Random.Range(y1, y2) );
            spawnCount++;
            // Create an enemy at the 'spawnPoint' position
            Instantiate(enemy, spawnPoint, Quaternion.identity);
        }
    }
}
