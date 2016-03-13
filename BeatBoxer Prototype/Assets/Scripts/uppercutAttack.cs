using UnityEngine;
using System.Collections;

public class uppercutAttack : MonoBehaviour {
    // Use this for initialization
    public float timeInBetweeen = .5f;
    int i;
    
    private string[] keyWumboCombo = { "J", "J", "J", "I", "Space" };
    public KeyCode[] wumboCombo;
    public Collider2D hookTrigger;
    private Animator anim;
   void Start()
    {
        for(int k=0; k < keyWumboCombo.Length; k++)
        {
            wumboCombo[k] = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyWumboCombo[k]);
            Debug.Log(wumboCombo[k]);
        }
    }
    void combo()
    {
    }
    // Update is called once per frame
    void Update() {
        detectButton();
    }
    void detectButton()
    {
        foreach (KeyCode mahKeys in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(mahKeys))
            {
                if (i < wumboCombo.Length&& Input.GetKeyDown(mahKeys) == Input.GetKeyDown(wumboCombo[i])) { 
                Debug.Log("key pressed "+ mahKeys+" counter "+i);
                i++;
                }
            }
         
        }


    }
 }
   

