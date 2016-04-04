using UnityEngine;
using System.Collections;

public class lightKickTrigger : MonoBehaviour {

    public BeatBoxerScript beatboxerStrength;
    private static int lightKickDamage = 7;
    private static float ludacris = 15;

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
            col.SendMessageUpwards("underAttack", lightKickDamage + beatboxerStrength.strength);
            col.SendMessageUpwards("knockMeBack", ludacris+ (beatboxerStrength.agility/2));
        }
        col.isTrigger = false;
    }
}
