
using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    //public GameObject menuCanvas;
    public bool quitClick;
    public bool startClicked;
    
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
}

