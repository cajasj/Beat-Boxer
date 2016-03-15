using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class increaseStats : MonoBehaviour {
    public bool isPaussed;
    public bool strengthClicked;
    public bool enduranceClicked;
    public bool agilityClicked;
    public bool vitalityClicked;
    public BeatBoxerScript beatBoxer;
    public userInterface spending;

    public int endurance;
    public int vitality;
    private int cost=5;
    void Update()
    {
        if (beatBoxer.currentExp > cost)
        {
            spending.spend(true);
            if (strengthClicked)
            {
                beatBoxer.strength += 1;
                beatBoxer.currentExp -= cost;
                cost = cost * 2;
            }
            strengthClicked = false;

            if (enduranceClicked)
            {
                beatBoxer.endurance += 1;
                beatBoxer.currentExp -= cost;
                cost = cost * 2;
            }
            enduranceClicked = false;
            if (agilityClicked)
            {
                beatBoxer.agility += 1;
                beatBoxer.currentExp -= cost;
                cost = cost * 2;
            }
            agilityClicked = false;
            if (vitalityClicked)
            {
                beatBoxer.vitality += 1;
                beatBoxer.currentExp -= cost;
                cost = cost * 2;
            }
            vitalityClicked = false;
        }
        else
        {
            spending.spend(false);

        }
    }
    public void clickedStrength()
    {
        strengthClicked = true;
    }
    public void clickedEndurance()
    {
        enduranceClicked = true;
    }
    public void clickedVitality()
    {
        vitalityClicked = true;
    }
    public void clickedAgility()
    {
        agilityClicked = true;
    }

}
