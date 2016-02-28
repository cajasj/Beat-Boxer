using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {


    // Update is called once per frame
    void OnGUI()
    {
        const int buttonWidth = 84;
        const int buttonHeight = 60;

        // Determine the button's place on screen
        // Center in X, 2/3 of the height in Y
        Rect buttonRect = new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (2 * Screen.height / 5) - (buttonHeight / 5),
              buttonWidth,
              buttonHeight
            );
       Rect buttonQuit = new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (2 * Screen.height / 3) - (buttonHeight / 3),
              buttonWidth,
              buttonHeight
            );
        if (GUI.Button(buttonRect, "Start!"))
        {
            Application.LoadLevel("testing");
        }
        if (GUI.Button(buttonQuit, "quit!"))
        {
            
            QuitGame();
        }
    }
    public void QuitGame(){
        Application.Quit();
    }
}
