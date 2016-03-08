using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class floatingDamage : MonoBehaviour {
    private float speed=1;
    public int damNumber;
    public Text displayNumb;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        displayNumb.text = "" + damNumber;
        transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime));
	}
}
