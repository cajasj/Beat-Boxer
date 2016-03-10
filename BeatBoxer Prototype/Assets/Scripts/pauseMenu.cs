using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour {
    public bool isPaussed;
    public GameObject pauseCanvas;
    public GameObject panel;
    public bool isClicked;
    public bool statClicked;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
	    if (isPaussed)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1f;
            isClicked = false;
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
            
        }
        else
        {
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
}
