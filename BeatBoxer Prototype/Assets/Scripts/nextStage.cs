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
        saveBeatBoxer();
        if (exitZone)
        {
           //saveBeatBoxer();

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
        }
    }
    void saveBeatBoxer()
    {


        PlayerPrefs.SetInt("exp", beatBoxerStats.currentExp);
        PlayerPrefs.SetInt("money", beatBoxerStats.currentMoney);
        PlayerPrefs.SetInt("strength", beatBoxerStats.strength);
        PlayerPrefs.SetInt("agility", (int)beatBoxerStats.agility);
        PlayerPrefs.SetInt("endurance", beatBoxerStats.endurance);
        PlayerPrefs.SetInt("vitality", beatBoxerStats.vitality);
        PlayerPrefs.SetInt("maxHealth", beatBoxerStats.maxHealth);
        PlayerPrefs.SetInt("health", beatBoxerStats.currentHealth);
        PlayerPrefs.SetInt("maxGuts", (int)beatBoxerStats.maxGuts);
        PlayerPrefs.SetInt("guts", (int)beatBoxerStats.guts);
        PlayerPrefs.SetInt("combo2", beatBoxerStats.combo2);
        PlayerPrefs.SetInt("combo3",beatBoxerStats.combo3);
        PlayerPrefs.SetInt("mixtape", beatBoxerStats.mixtape);
        PlayerPrefs.SetInt("mixtapeOn", beatBoxerStats.mixtapeOn);
        PlayerPrefs.SetInt("expCost", beatBoxerStats.expCost);
    }
}
