using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static_Slots_System : MonoBehaviour
{
    [HideInInspector]
    public Slots_DataBase dataBase;
    public Static_Slot[] staticSlots;

    private void Awake()
    {
        dataBase = GameObject.FindGameObjectWithTag("GameController").GetComponent<Slots_DataBase>();
    }
    private void Start()
    {
        Search_Start_EmptySlots();
    }

    // start
    private void Search_Start_EmptySlots()
    {
        for (int i = 0; i < staticSlots.Length; i++)
        {
            if (staticSlots[i].currentItem == null)
            {
                staticSlots[i].Empty_Slot();
            }
        }
    }

    // check
    public bool Slot_Available()
    {
        for (int i = 0; i < staticSlots.Length; i++)
        {
            if (!staticSlots[i].hasItem)
            {
                return true;
            }
        }
        return false;
    }
    public bool Same_Item_Stack_Available(Item_Info itemInfo)
    {
        for (int i = 0; i < staticSlots.Length; i++)
        {
            if (itemInfo == staticSlots[i].currentItem && staticSlots[i].itemAmount < itemInfo.itemMaxAmount)
            {
                return true;
            }
        }
        return false;
    }
    public void Over_MaxAmount_Devide(Static_Slot staticSlot)
    {
        if (staticSlot.itemAmount > staticSlot.currentItem.itemMaxAmount)
        {
            int leftOver = staticSlot.itemAmount - staticSlot.currentItem.itemMaxAmount;

            if (Slot_Available())
            {
                Add_Item(staticSlot.currentItem, leftOver);
            }
            else if (!Slot_Available())
            {
                dataBase.MoveSlot_to_Slots_System(staticSlot.currentItem, leftOver);
            }

            staticSlot.itemAmount = staticSlot.currentItem.itemMaxAmount;
            staticSlot.amountText.text = staticSlot.itemAmount.ToString();
        }
    }

    // in
    private void Add_Item(Item_Info itemInfo, int amount)
    {
        for (int i = 0; i < staticSlots.Length; i++)
        {
            if (staticSlots[i].currentItem == null)
            {
                staticSlots[i].Assign_Slot(itemInfo, amount);
                break;
            }
        }
    }
    public bool Check_Add_Item (Item_Info itemInfo, int amount)
    {
        for (int i = 0; i < staticSlots.Length; i++)
        {
            if (Same_Item_Stack_Available(itemInfo) && Slot_Available())
            {
                // empty other slot
                staticSlots[i].Stack_Slot(amount);
                Over_MaxAmount_Devide(staticSlots[i]);
                return true;
            }
            else if (Slot_Available())
            {
                // empty other slot
                Add_Item(itemInfo, amount);
                return true;
            }
        }
        return false;
    }

    // resest
    public void DeSelect_All_Slots()
    {
        for (int i = 0; i < staticSlots.Length; i++)
        {
            staticSlots[i].DeSelect_Slot();
        }
    }
}
