using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class userInterface : MonoBehaviour {
    public BeatBoxerScript myStats;
    private bool givePlayer;
    public Text gutsu;
    public Text myEXP;
    public Text healthPoint;
    public Text myMoney;
    public int myGuts;
    
    // Use this for initialization
    void Start () {
        healthPoint.text = myStats.currentHealth.ToString();
        gutsu.text = myStats.guts.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        myGuts = (int)myStats.guts;
        healthPoint.text = myStats.currentHealth.ToString();
        gutsu.text = myGuts.ToString();
        if (givePlayer)
        {
            myMoney.text= "$" + myStats.currentMoney;
            myEXP.text= myStats.currentExp.ToString();
            givePlayer = false;
        }
	}
    public void awardPlayer(bool unlock)
    {
        givePlayer = unlock;
    }
}
