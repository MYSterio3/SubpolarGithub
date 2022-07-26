using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots_System : MonoBehaviour
{
    [HideInInspector]
    public Slots_DataBase dataBase;
    public Slot[] slots;


    private void Awake()
    {
        dataBase = GameObject.FindGameObjectWithTag("GameController").GetComponent<Slots_DataBase>();
    }
    private void Start()
    {
        Search_Start_EmptySlots();
    }

    public void Connect_toDataBase()
    {
        dataBase.Connect_Slots_System(this);
    }

    // start
    private void Search_Start_EmptySlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].currentItem == null)
            {
                slots[i].Empty_Slot();
            }
        }
    }

    // check
    public bool Slot_Available()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].hasItem)
            {
                return true;
            }
        }
        return false;
    }
    public bool Other_Slot_Available()
    {
        if (dataBase.staticSlotsSystem.Slot_Available())
        {
            return true;
        }
        else return false;
    }

    // in
    public void Assign_to_EmptySlot(Item_Info itemInfo, int amount)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].hasItem)
            {
                // stack check

                slots[i].Assign_Slot(itemInfo, amount);
                break;
            }
        }
    }

    // resest
    public void DeSelect_All_Slots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].DeSelect_Slot();
        }
    }

    // test
    public void Craft_Item(Item_Info item)
    {
        Assign_to_EmptySlot(item, 1);
    }
}
