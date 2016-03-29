using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class blastScript : MonoBehaviour {

    public bool firingBlast;
    public Transform beatBoxerPosition;
    public GameObject beatBoxerBlast;
    public GameObject clonedBlast;
    public float blastDamage = 1;
    // Use this for initialization
    void awake () {
            }
	
	// Update is called once per frame
	void Update () {
        if (firingBlast)
        {

            Instantiate(beatBoxerBlast, beatBoxerPosition.position, beatBoxerPosition.rotation);
      
        }
      
    }
  
    public void inputFlag(bool flag)
    {
        firingBlast = flag;
    }
   
}
