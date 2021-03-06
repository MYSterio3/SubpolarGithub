using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public BoxSlot_UI boxSlotUI;

    public List<Item_Info> itemInfo = new List<Item_Info>();
    public List<GameObject> playerItems = new List<GameObject>();

    private void Update()
    {
        Item_Active_Update();
    }

    private void Item_Active_Update()
    {
        for (int i = 0; i < itemInfo.Count; i++)
        {
            if (boxSlotUI.assignedBoxSlot.itemInfo == itemInfo[i])
            {
                playerItems[i].SetActive(true);
            }
            else
            {
                playerItems[i].SetActive(false);
            }
        }
    }
}
