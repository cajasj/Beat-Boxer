﻿using UnityEngine;
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
        healthPoint.text = PlayerPrefs.GetInt("health").ToString();
        gutsu.text = PlayerPrefs.GetInt("guts").ToString();
        myMoney.text = "$" + PlayerPrefs.GetInt("money");
        myEXP.text = PlayerPrefs.GetInt("exp").ToString();
    }
	void Awake()
    {
    }
	// Update is called once per frame
	void Update () {
        //myGuts = (int)myStats.guts;
        healthPoint.text = PlayerPrefs.GetInt("health").ToString();
        gutsu.text = PlayerPrefs.GetInt("guts").ToString();
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
    public void spend(bool unlock)
    {
        givePlayer = unlock;
    }
}
