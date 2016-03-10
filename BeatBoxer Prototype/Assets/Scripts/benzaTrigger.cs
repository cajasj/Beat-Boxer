using UnityEngine;
using System.Collections;

public class benzaTrigger : MonoBehaviour {
    public BeatBoxerScript beatboxerStrength;
    private static int benzaDamage = 10;
    private static float ludacris = 20;

    GameObject col;
    void Start()
    {
        

    }
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.isTrigger == false && col.CompareTag("enemy"))
        {
          col.isTrigger = true;
          col.SendMessageUpwards("underAttack", benzaDamage+beatboxerStrength.strength);
          col.SendMessageUpwards("knockMeBack", ludacris);
        }
        col.isTrigger = false;
    }
}
