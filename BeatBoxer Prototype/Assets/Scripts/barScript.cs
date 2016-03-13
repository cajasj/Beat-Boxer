using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class barScript : MonoBehaviour {
    public float barsForDaysGuts;
    public float maxBarsGuts;
    public float barsForDaysHealth;
    public float maxBarsHealth;
    GameObject beatBoxer;
    public Image barsGuts;
    public Image barsHealth;
    BeatBoxerScript beatBoxerStats;

	// Use this for initialization
	void Start () {
        beatBoxer = GameObject.Find("Player");
        beatBoxerStats = beatBoxer.GetComponent<BeatBoxerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        barsForDaysGuts = beatBoxerStats.guts;
        maxBarsGuts = beatBoxerStats.maxGuts;
        straightBarsGuts();
        barsForDaysHealth = beatBoxerStats.currentHealth;
        maxBarsHealth = beatBoxerStats.maxHealth;
        straightBarsHealth();
    }
    private void straightBarsGuts()
    {
        barsGuts.fillAmount = barsForDaysGuts/maxBarsGuts;
    }
    private void straightBarsHealth()
    {
        barsHealth.fillAmount = barsForDaysHealth/ maxBarsHealth;
    }
}
