using UnityEngine;
using System.Collections;

public class afterDefeat : MonoBehaviour {
    private bool defeated=false;
    public bool quitClick;
    public bool reDoClick;
    public GameObject pauseCanvas;
    public GameObject panel;
    public BeatBoxerScript beatBoxerHealth;
    public Animator anim;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (defeated)

        {

            //beatBoxerHealth.beatBoxerMovement.SetBool("noHealth", true);
            pauseCanvas.SetActive(true);
            panel.SetActive(true);
            Time.timeScale = 0f;
            if (quitClick)
            {
                Application.Quit();
            }
            if (reDoClick)
            {
                beatBoxerHealth.currentHealth = beatBoxerHealth.maxHealth / 2;
                Time.timeScale = 1f;
               // anim.SetBool("noHealth", false);
                defeated = false;
                reDoClick = false;
                pauseCanvas.SetActive(false);
                panel.SetActive(false);
            }
        }
        else
        {
            pauseCanvas.SetActive(false);
            panel.SetActive(false);
        }
      
    }
    public void youLose (bool lost){
        defeated = lost;
    }
    public void giveUp()
    {
        quitClick = true;
    }
    public void neverGiveUp()
    {
        reDoClick = true;
    }
}
