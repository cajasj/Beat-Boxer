using UnityEngine;
using System.Collections;

public class disableTempCollider : MonoBehaviour {
    
    public GameObject searchingEnemy;
    private BoxCollider2D nextCollider;
    // Use this for initialization
    void Start()
    {
        findEnemies();
        nextCollider = GetComponent<BoxCollider2D>();
        nextCollider.enabled = true;
    }
    void findEnemies()
    {
        searchingEnemy = GameObject.FindWithTag("enemy");
        if (!searchingEnemy)
        {
            nextCollider = GetComponent<BoxCollider2D>();
            nextCollider.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        findEnemies();
    }
    
}
