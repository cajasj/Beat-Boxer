using UnityEngine;
using System.Collections;

public class hookTrigger : MonoBehaviour
{
    private static int hookDamage = 10;
    public BeatBoxerScript beatboxerStrength;
    private static float ludacris = 1100;

    GameObject col;
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.isTrigger == false && col.CompareTag("enemy"))
        {
            col.isTrigger = true;
            col.SendMessageUpwards("underAttack", hookDamage+beatboxerStrength.strength);
            col.SendMessageUpwards("knockMeDown", ludacris);
        }
        col.isTrigger = false;
    }

}
