using UnityEngine;
using System.Collections;

public class jabTrigger : MonoBehaviour {
    private static int jabDamage = 10;
    private static float ludacris = 13;
    public BeatBoxerScript beatboxerStrength;
    public GameObject damNumber;
    GameObject col;
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        
            if (col.isTrigger == false && col.CompareTag("enemy"))
            {
            col.isTrigger = true;
                col.SendMessageUpwards("underAttack", (jabDamage+beatboxerStrength.strength)/2);
            col.SendMessageUpwards("knockMeBack", ludacris);
           

        }
        col.isTrigger = false;
    }
   
}
