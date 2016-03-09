using UnityEngine;

using System.Collections.Generic;
public class shopitemDB {
    static private List<shop> _items;

    static private bool _isDatabaseLoaded = false;
    

    static private void ValidateDatabase()
    {
        if (_items == null)
        {
            _items = new List<shop>();
        }
        if (!_isDatabaseLoaded)
        {
            loadDatabase();
        }
    }
    static public void loadDatabase()
    {
        if (_isDatabaseLoaded)
        {
            return;
        }
        _isDatabaseLoaded = true;
        loadDatabaseForce();
    }
    static public void loadDatabaseForce()
    {
        ValidateDatabase();
        shop[] shopItemList = Resources.LoadAll<shop>(@"shopItems");
        foreach(shop item in shopItemList)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }
    }
    static public void ClearDatabase()
    {
        _isDatabaseLoaded = false;
        _items.Clear();
    }
    static public shop GetItem(int id)
    {
        ValidateDatabase();
        foreach(shop item in _items)
        {
            if (item.itemID == id)
            {
                return ScriptableObject.Instantiate(item) as shop;
            }
        }
        return null;
    }
}
