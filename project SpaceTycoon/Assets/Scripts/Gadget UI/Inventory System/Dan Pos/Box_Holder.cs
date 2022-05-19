using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Box_Holder : MonoBehaviour
{   
    private void Awake()
    {
        _boxSystem = new Box_System(boxSize);
    }

    private void Start()
    {
        Unlock_Current_Inventory_atStart();
    }

    [SerializeField] private int boxSize;

    [SerializeField] protected Box_System _boxSystem;
    public Box_System boxSystem => _boxSystem;

    [SerializeField] private BoxSlot_UI[] _currentInventorySlots;
    public BoxSlot_UI[] currentInventorySlots => _currentInventorySlots;

    public static UnityAction<Box_System> boxSlotUpdateRequested;


    // slot space available check before crafting item
    bool Slot_Full_Check()
    {
        for (int i = 0; i < _boxSystem.boxSlots.Count; i++) // goes through all slots until it finds an available slot
        {
            if (_boxSystem.boxSlots[i].itemInfo == null && _boxSystem.boxSlots[i].unlocked)
            {
                return true; // if it finds the first available slot, it returns true and breaks the loop
            }
        }
        return false; // if it went through everything and couldn't find an available slot, it returns false
    }
    // check if wanted crafting item can be stacked when all slots are full
    bool Slot_StackFull_Check(Item_Info itemToAdd, int amountToAdd)
    {
        if (_boxSystem.Contains_Item(itemToAdd, out List<Box_Slot> boxSlot))
        {
            foreach (var slot in boxSlot)
            {
                if (slot.Room_left_Stack(amountToAdd))
                {
                    return true;
                }
            }
        }
        return false;
    }

    // craft item function
    public List<Item_Info> items = new List<Item_Info>();
    public void Craft_Item(int itemNum, int amount)
    {
        if (Slot_Full_Check() || Slot_StackFull_Check(items[itemNum], amount))
        {
            _boxSystem.Add_to_Box(items[itemNum], amount);
        }
    }



    void Restart_Slot_Level()
    {
        for (int i = 0; i < _boxSystem.boxSlots.Count; i++)
        {
            _boxSystem.boxSlots[i].unlocked = false;
        }
    }
    void Unlock_Current_Inventory_atStart()
    {
        for (int i = 0; i < _currentInventorySlots.Length; i++)
        {
            _currentInventorySlots[i].assignedBoxSlot.unlocked = true;
        }
    }

    int endi;
    public void Unlock_Slot_Level(int wantedLevel)
    {
        // restart slot unlock state
        Restart_Slot_Level();

        // assign slots
        if (wantedLevel == 1) { endi = 4; }
        if (wantedLevel == 2) { endi = 8; }
        if (wantedLevel == 3) { endi = 12; }
        if (wantedLevel == 4) { endi = 16; }
        if (wantedLevel == 5) { endi = 20; }
        if (wantedLevel == 6) { endi = 24; }

        // unlock assigned slots
        for (int i = 0; i < endi; i++)
        {
            _boxSystem.boxSlots[i].unlocked = true;
        }
    }
}
