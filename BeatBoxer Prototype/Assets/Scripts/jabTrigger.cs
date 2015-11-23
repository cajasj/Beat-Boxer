using UnityEngine;
using System.Collections;

public class jabTrigger : MonoBehaviour {
    public int jabDamage = 10;

    void onTriggerEnter2D(Collider2D col)
    {
        Debug.Log("collision1");
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("attacking", jabDamage);
            Debug.Log("collision");
        }
    }
    //Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
