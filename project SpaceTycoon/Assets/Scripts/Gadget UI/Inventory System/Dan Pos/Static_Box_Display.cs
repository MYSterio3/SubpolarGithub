using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Static_Box_Display : Box_Display
{
    [SerializeField] private Box_Holder _boxHolder;
    [SerializeField] private BoxSlot_UI[] _slots;
    public BoxSlot_UI[] slots => _slots;
    [SerializeField] private BoxSlot_UI[] _currentInventorySlots;
    public BoxSlot_UI[] currentInventorySlots => _currentInventorySlots;

    protected override void Start()
    {
        base.Start();

        if (_boxHolder != null)
        {
            _boxSystem = _boxHolder.boxSystem;
            _boxSystem.boxSlotUpdate += Update_Slot;
        }

        Assign_Slot(_boxSystem);

        Unlock_Current_Inventory_atStart();
    }

    public override void Assign_Slot(Box_System boxToDisplay)
    {
        _slotDictionary = new Dictionary<BoxSlot_UI, Box_Slot>();

        for (int i = 0; i < _boxSystem.boxSize; i++)
        {
            _slotDictionary.Add(_slots[i], _boxSystem.boxSlots[i]);
            _slots[i].Init(_boxSystem.boxSlots[i]);
        }
    }

    public void Unlock_Bag_Level(int starti, int endi, int currentBagLevel)
    {
        // slot unlock for bag level
        for (int i = starti; i < endi; i++)
        {
            _slots[i].unlocked = true;
            _slots[i].Slot_Status_Update();
        }
    }

    void Unlock_Current_Inventory_atStart()
    {
        for (int i = 0; i < _currentInventorySlots.Length; i++)
        {
            _currentInventorySlots[i].unlocked = true;
        }
    }
}
  