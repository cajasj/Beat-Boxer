using UnityEngine;
using System.Collections;

public class uppercutTrigger : MonoBehaviour {

    private static int hookDamage = 25;
    GameObject col;
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.isTrigger == false && col.CompareTag("enemy"))
        {
            col.isTrigger = true;
            col.SendMessageUpwards("underAttack", hookDamage);
        }
        col.isTrigger = false;
    }
}
