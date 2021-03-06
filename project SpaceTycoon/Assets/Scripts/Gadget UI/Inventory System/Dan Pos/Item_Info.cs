using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    hand, back, throwable
}

public enum ItemType2
{
    item, ingredient
}

[CreateAssetMenu(menuName = "Create New Item")]
public class Item_Info : ScriptableObject
{
    public ItemType itemType;
    public ItemType2 itemType2;
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
    public int itemMaxAmount;
}
