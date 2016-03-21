using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour {
    public bool isPaussed;
    public GameObject pauseCanvas;
    public GameObject panel;
    public GameObject statPanel;
    public bool isClicked;
    public bool statClicked;
    public Text strengthTXT;
    public Text agilityTXT;
    public Text enduranceTXT;
    public Text vitalityTXT;
    public BeatBoxerScript beatBoxerStats;
    // Use this for initialization


    // Update is called once per frame
    void Update () {
        strengthTXT.text = "Strength: " + beatBoxerStats.strength;
        agilityTXT.text = "Agility: " + beatBoxerStats.agility;
        vitalityTXT.text = "Vitality: " + beatBoxerStats.vitality;
        enduranceTXT.text = "Endurance: " + beatBoxerStats.endurance;
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
            statPanel.SetActive(true);
        }
        else
        {
            statPanel.SetActive(false);
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
    public void closeStatsMenu()
    {
        statClicked = false;
    }
}
