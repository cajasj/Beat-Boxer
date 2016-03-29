using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour {
    public bool isPaussed;
    public GameObject pauseCanvas;
    public GameObject panel;
    public GameObject statPanel;
    public GameObject equipPanel;
    public GameObject comboPanel;
    public GameObject generalPanel;
    public GameObject statTab;
    public GameObject equipTab;
    public GameObject comboTab;
    public GameObject close;
    public bool isClicked;
    public bool statClicked;
    public bool comboClicked;
    public bool equipClicked;
    public bool myStatClicked;
    public Text strengthTXT;
    public Text agilityTXT;
    public Text enduranceTXT;
    public Text vitalityTXT;
    public Text comboName2;
    public Text comboInput2;
    public Text comboName3;
    public Text comboInput3;
    public BeatBoxerScript beatBoxerStats;

    // Use this for initialization
 

    // Update is called once per frame
    void Update () {
        strengthTXT.text = "Strength: " + beatBoxerStats.strength;
        agilityTXT.text = "Agility: " + beatBoxerStats.agility;
        vitalityTXT.text = "Vitality: " + beatBoxerStats.vitality;
        enduranceTXT.text = "Endurance: " + beatBoxerStats.endurance;
        if (beatBoxerStats.combo2==1)
        {
            comboName2.text = "Hammer Time";
            comboInput2.text = "Left/Right, Right/Left, Crouch, I";
        }
        if (beatBoxerStats.combo3 == 1)
        {
            comboName3.text = "Enogee Blast";
            comboInput3.text = "Down, Right/Left, Crouch, J";
        }
        if (isPaussed)
        {

            pauseCanvas.SetActive(true);
            Time.timeScale = 0f;
            
        }
        else
        {
            pauseCanvas.SetActive(false);
            statPanel.SetActive(false);
            Time.timeScale = 1f;
            isClicked = false;
            statClicked = false;
            statTab.SetActive(false);
            equipTab.SetActive(false);
            comboTab.SetActive(false);
            close.SetActive(false);
        }
        if (isClicked)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
        if (statClicked)
        {
            statTab.SetActive(true);
            equipTab.SetActive(true);
            comboTab.SetActive(true);
            generalPanel.SetActive(true);
            close.SetActive(true);
        }
        else
        {
            generalPanel.SetActive(false);
        }
        if (myStatClicked)
        {
         
            statPanel.SetActive(true);

        }else
        {
            statPanel.SetActive(false);
        }
        if (comboClicked)
        {

            
            comboPanel.SetActive(true);
        }
        else
        {
            comboPanel.SetActive(false);
        }
        if (equipClicked)
        {
         
            equipPanel.SetActive(true);
            
        }
        else
        {
            equipPanel.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaussed = !isPaussed;
          

        }
    }
    public void resume()
    {
        isPaussed = false;
    }
    public void openQuitSub()
    {
        isClicked = true;
        Debug.Log("in the open sub");
    }
   public void noQuit()
    {
        isClicked=false;
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void statsMenu()
    {
        statClicked = true;
    }
    public void statsMenutab()
    {
        myStatClicked = true;
        comboPanel.SetActive(false);
        comboClicked = false;
        equipPanel.SetActive(false);
        equipClicked = false;
    }
    public void comboMenu()
    {
        statPanel.SetActive(false);
        myStatClicked = false;
        equipPanel.SetActive(false);
        equipClicked = false;
        comboClicked =true;
    }
    public void equipMenu()
    {
        statPanel.SetActive(false);
        myStatClicked = false;
        comboPanel.SetActive(false);
        comboClicked = false;
        equipClicked = true;
    }
    public void closeStatsMenu()
    {
        statClicked = false;
        comboClicked = false;
        equipClicked = false;
        close.SetActive(false);
        statTab.SetActive(false);
        equipTab.SetActive(false);
        comboTab.SetActive(false);
    }
}
