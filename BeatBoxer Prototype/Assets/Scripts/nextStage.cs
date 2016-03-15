using UnityEngine;
using System.Collections;

public class nextStage : MonoBehaviour {
    public string stageToLoad;
    private bool exitZone;
    private BeatBoxerScript beatBoxerStats;
    public GameObject beatBoxer;
	// Use this for initialization
	void Start () {
        exitZone = false;

        beatBoxerStats = beatBoxer.GetComponent<BeatBoxerScript>();
	
    }
    void Update()
    {
        if (exitZone)
        {
            saveBeatBoxer();
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
    void saveBeatBoxer()
    {
        Debug.Log(beatBoxerStats.currentExp);
        PlayerPrefs.SetInt("exp", beatBoxerStats.currentExp);
        PlayerPrefs.SetInt("money", beatBoxerStats.currentMoney);
        PlayerPrefs.SetInt("strength", beatBoxerStats.strength);
        PlayerPrefs.SetInt("agility", (int)beatBoxerStats.agility);
        PlayerPrefs.SetInt("endurance", beatBoxerStats.endurance);
        PlayerPrefs.SetInt("vitality", beatBoxerStats.vitality);
        PlayerPrefs.SetInt("health", beatBoxerStats.currentHealth);
        PlayerPrefs.SetInt("guts", (int)beatBoxerStats.guts);
    }
}
