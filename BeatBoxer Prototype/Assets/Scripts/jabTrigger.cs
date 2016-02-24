using UnityEngine;
using System.Collections;

public class jabTrigger : MonoBehaviour {
    private static int jabDamage = 10;
    public GameObject animationObject;
    GameObject col;
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        
            if (col.isTrigger == false && col.CompareTag("enemy"))
            {
            col.isTrigger = true;
                col.SendMessageUpwards("underAttack", jabDamage);
            }col.isTrigger = false;
    }
   
}
