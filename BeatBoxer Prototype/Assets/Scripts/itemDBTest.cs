using UnityEngine;
using System.Collections;

public class itemDBTest : MonoBehaviour {
    int i;
	// Use this for initialization
	void Start () {

        for (i = 1; i < 4; i++)
        {
            shop item = shopitemDB.GetItem(i);
            Debug.Log(string.Format("ID {0} |Name {1} |Description {2}",item.itemID,item.itemName,item.description));
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
