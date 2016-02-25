using UnityEngine;
using System.Collections;

public class benzaTrigger : MonoBehaviour {

    private static int benzaDamage = 30;
    GameObject col;
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.isTrigger == false && col.CompareTag("enemy"))
        {
            col.isTrigger = true;
            col.SendMessageUpwards("underAttack", benzaDamage);
        }
        col.isTrigger = false;
    }
}
