using UnityEngine;
using System.Collections;

public class comboSystemClass {

    public string[] combo;
    private int i=0;
    private float comboReset=1.2f;
    private bool returnMe = false;
    public comboSystemClass(string[] wumbo)
    {
        combo = wumbo;
    }
    public comboSystemClass(bool stop)
    {
        returnMe = stop;
    }
    public bool check()

    {

         resetTimer();
        detectButton();
        return returnMe;
    }
    void detectButton()
    {
        foreach (KeyCode mahKeys in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(mahKeys))
            {

                if (i < combo.Length && Input.GetKeyDown(mahKeys) == Input.GetButtonDown(combo[i]))
                {

                    //Debug.Log("key pressed "+ mahKeys+" counter "+i);
                    i++;
                    comboReset = .8f;
                   
                }
                else
                {
                    i = 0;
                    returnMe = false;
                    Debug.Log("messed up the combo you pressed " + mahKeys);

                }
                if (i >= combo.Length)
                {
                    i = 0;
                    returnMe = true;
                    Debug.Log("complete sequence of button press");

                }
                else
                {
                    returnMe = false;
                }

            }

        }

    }
    void resetTimer()
    {
        if (comboReset > 0)
        {
            comboReset -= Time.deltaTime;
        }
        else
        {
            i = 0;
            returnMe = false;
        }
    }
}
