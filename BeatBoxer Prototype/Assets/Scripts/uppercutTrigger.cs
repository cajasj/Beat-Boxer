using UnityEngine;
using System.Collections;

public class upperCutTrigger : MonoBehaviour {
    public BeatBoxerScript beatboxerStrength;
    private static int upperCutDamage = 50;
    private static float ludacris = 20;
    
    GameObject col;
  
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.isTrigger == false && col.CompareTag("enemy"))
        {
            col.isTrigger = true;
            col.SendMessageUpwards("underAttack", upperCutDamage + beatboxerStrength.strength);
            col.SendMessageUpwards("knockMeUp", ludacris);
        }
        col.isTrigger = false;
    }
}
