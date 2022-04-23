using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory_Object : ScriptableObject
{
    public List<Inventory_Slot> container = new List<Inventory_Slot>();

    public void Add_Item(Item_Object itemObject, int amount)
    {
        bool hasItem = false;
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].itemObject == itemObject)
            {
                container[i].Add_Amount(amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            container.Add(new Inventory_Slot(itemObject, amount));
        }
    }
}

[System.Serializable]
public class Inventory_Slot
{
    public Item_Object itemObject;
    public int amount;
    public Inventory_Slot(Item_Object itemObject, int amount)
    {
        this.itemObject = itemObject;
        this.amount = amount;
    }

    public void Add_Amount(int amount)
    {
        this.amount += amount;
    }

    public void Decrease_Amount(int amount)
    {
        this.amount -= amount;
    }
}
