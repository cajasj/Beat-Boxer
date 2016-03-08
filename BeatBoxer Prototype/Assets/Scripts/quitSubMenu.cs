using UnityEngine;
using System.Collections;

public class quitSubMenu : MonoBehaviour {
    public bool quitClick;
    public GameObject quitCanvas;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (quitClick)
        {
            quitCanvas.SetActive(true);
          
        }
        else
        {
            quitCanvas.SetActive(false);
        }

        
    }
    public void noQuit(bool isClick)
    {
        quitClick = !isClick;
        Debug.Log("no quit function-");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
