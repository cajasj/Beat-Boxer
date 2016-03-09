using UnityEngine;
using System.Collections;
using UnityEditor;
public class makeItem {
    [MenuItem("Assets/Create/shop/Item")]

    public static void makeItems()
    {
        shop asset = ScriptableObject.CreateInstance<shop>();
        AssetDatabase.CreateAsset(asset, "Assets/newItem.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
    

}
