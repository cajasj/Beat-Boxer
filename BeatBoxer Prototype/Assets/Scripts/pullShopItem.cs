using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class pullShopItem : MonoBehaviour {
    
    public int myNum;
    public Text myName;
    public Text cost;
    public Text description;
    public Text gutsu;
    public Text dam;
    public int i;
    public BeatBoxerScript mylist;
    // Use this for initialization
    void Start () {
        SetButton();
    }

    void SetButton()
    {
      
        myName.text = mylist.shoppingList[myNum].itemName;
        cost.text = "$"+mylist.shoppingList[myNum].money.ToString();
        description.text = mylist.shoppingList[myNum].description;
        dam.text = "Damage: " + mylist.shoppingList[myNum].damage.ToString();
        gutsu.text = "Guts: "+ mylist.shoppingList[myNum].gutsCost.ToString();

    }
   
    // Update is called once per frame
    void Update () {
	
	}
}
