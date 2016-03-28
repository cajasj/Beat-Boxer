using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class itemShop : MonoBehaviour
{
    public bool isPaussed;
    public bool combo2Clicked;
    public bool combo3Clicked;
    public bool mixTapeClicked;
    public BeatBoxerScript beatBoxer;
    public userInterface spending;
    public Text Description;
    public Text moneyCost;
    public int combo2Cost=20;
    public int combo3Cost=30;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (beatBoxer.currentMoney > combo2Cost)
        {
            spending.spend(true);
            if (combo2Clicked&&beatBoxer.combo2 == 0)
            {
                beatBoxer.currentMoney -= combo2Cost;
                beatBoxer.combo2 = 1;
            }
        }
        if (beatBoxer.currentMoney > combo2Cost) { 
            if (combo3Clicked && beatBoxer.combo3==0)
            {
                spending.spend(true);
                beatBoxer.combo3 = 1;
                beatBoxer.currentMoney -= combo3Cost;
            }
        }
        if (mixTapeClicked && beatBoxer.mixtape==0)
        {
            beatBoxer.mixtape = 1;
        }

       

    }
    public void combo2Click()
    {
        combo2Clicked = true;
    }
    public void combo3Click()
    {
        combo3Clicked = true;
    }
    public void mixtapeClick()
    {
        mixTapeClicked = true;
    }
    public void hoverCombo2()
    {
        moneyCost.text = "$" + combo2Cost;
        Description.text = "Washed up man was strap \nfor cash so he sold his \nsigniature move";
    }
    public void hoverCombo3()
    {
        moneyCost.text = "$" + combo3Cost;
        Description.text = "Technique that was \npassed down from fighters\nfrom the streets";
    }
    public void hoverMixtape()
    {
        moneyCost.text = "  Free Fam";
        Description.text = "Check out my Mixtape \nfam it's straight fire";
    }
}