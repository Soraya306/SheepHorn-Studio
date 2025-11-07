using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Item",menuName ="Item/Create New Item")]
public class Item : ScriptableObject
{
    //DATOS DE LOS ITEMS 

    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
}
