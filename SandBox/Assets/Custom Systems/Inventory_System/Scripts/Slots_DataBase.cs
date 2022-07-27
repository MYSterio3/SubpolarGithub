using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots_DataBase : MonoBehaviour
{
    public Static_Slots_System staticSlotsSystem;
    public Slots_System slotsSystem;

    public void Connect_Slots_System(Slots_System slotsSystem)
    {
        this.slotsSystem = slotsSystem;
    }
    public void Reset_Slots_System()
    {
        slotsSystem = null;
    }

    public void MoveSlot_to_StaticSlotsSystem(Item_Info itemInfo, int amount)
    {
        staticSlotsSystem.Check_Add_Item(itemInfo, amount);
    }
    public void MoveSlot_to_Slots_System(Item_Info itemInfo, int amount)
    {
        slotsSystem.Check_Add_Item(itemInfo, amount);
    }
}
