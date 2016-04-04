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
    public Text Description;
    public Text expCost;
    public int endurance;
    public int vitality;
    public int cost=5;
    void Start() {
        Description.text = "Description";
        
        cost = PlayerPrefs.GetInt("expCost");
    }


    void Update()
    {
        expCost.text = "EXP to increase Stat:\n " + cost;
        if (beatBoxer.currentExp > cost)
        {
            spending.spend(true);
            if (strengthClicked)
            {
                beatBoxer.strength += 1;
                beatBoxer.currentExp -= cost;
                cost = cost*2;
                
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
            PlayerPrefs.SetInt("expCost", cost);
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
    public void hoverStrength()
    {
        Description.text = "Increase attack strength";
    }
    public void hoverAgility()
    {
        Description.text = "Increase Speed and \nKnockBack";
    }
    public void hoverEndurance()
    {
        Description.text = "Increase Guts and \nGuts Rengeneration";
    }
    public void hoverVitality()
    {
        Description.text = "Increase your HP";
    }
}
