
using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    //public GameObject menuCanvas;
    public bool quitClick;
    public bool startClicked;
    public bool controlsClicked;
    public bool closeClicked;
    public GameObject keyboardPanel;
    void Start()
    {
        controlsClicked = false;
    }
    void Update()
    {
        if (quitClick)
        {
            QuitGame();
        }
        if (startClicked)
        {
            startGame();
        }
       if (controlsClicked)
        {
            keyboardPanel.SetActive(true);
        }
        else
        {
            keyboardPanel.SetActive(false);
        }
     
    }
    public void startGame()
    {
        Application.LoadLevel("testing");
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.SetInt("exp", 0);
        PlayerPrefs.SetInt("strength", 1);
        PlayerPrefs.SetInt("endurance", 1);
        PlayerPrefs.SetInt("vitality", 1);
        PlayerPrefs.SetInt("agility", 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void howToPanel()
    {
        controlsClicked = true;
    }
    public void closePanel()
    {
        controlsClicked = false;
    }
}

