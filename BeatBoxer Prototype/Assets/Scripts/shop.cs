using UnityEngine;
using System.Collections;
[System.Serializable]
public class shop : ScriptableObject {
    public int itemID;
    public string itemName;
    public int money;
    public string description;
    public int damage;
    public int knockback;
    public int gutsCost;
    public bool sold;
}
