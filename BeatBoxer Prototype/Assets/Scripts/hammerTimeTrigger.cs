using UnityEngine;
using System.Collections;

public class hammerTimeTrigger : MonoBehaviour {

    public BeatBoxerScript beatboxerStrength;
    private static int hammerTimeDamage = 90;
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
            col.SendMessageUpwards("underAttack", hammerTimeDamage + beatboxerStrength.strength);
            Debug.Log(hammerTimeDamage);
            col.SendMessageUpwards("knockMeBack", ludacris);
        }
        col.isTrigger = false;
    }
}
