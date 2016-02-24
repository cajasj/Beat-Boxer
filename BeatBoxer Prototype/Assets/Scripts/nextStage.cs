using UnityEngine;
using System.Collections;

public class nextStage : MonoBehaviour {
    public string stageToLoad;
    private bool exitZone;
	// Use this for initialization
	void Start () {
        exitZone = false;

	
    }
    void Update()
    {
        if (exitZone)
        {
            Application.LoadLevel(stageToLoad);
            Debug.Log(stageToLoad);
        }

    }
    // Update is called once per frame
 
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.name =="Player")
        {
            exitZone = true;
            Debug.Log("collide with zone-");
        }
    }
}
