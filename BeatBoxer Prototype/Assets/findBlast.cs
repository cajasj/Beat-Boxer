using UnityEngine;
using System.Collections;

public class findBlast : MonoBehaviour {
    public GameObject searchingBlast;
    private BoxCollider2D nextCollider;
    public bool deadEnemies;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        findEnergyBlast();
	}
    void findEnergyBlast()
    {
        searchingBlast = GameObject.FindWithTag("energyBlast");
        if (searchingBlast)
        {
            SendMessageUpwards("blastSpeed", 10f);
        }

    }
}
