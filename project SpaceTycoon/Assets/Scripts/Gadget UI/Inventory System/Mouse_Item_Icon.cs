using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mouse_Item_Icon : MonoBehaviour
{
    public Image itemSprite;
    public Text itemCount;
    public Box_Slot assignedBoxSlot;

    private void Awake()
    {
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }

    public void Update_Mouse_Slot(Box_Slot boxSlot)
    {
        assignedBoxSlot.Assign_Item(boxSlot);
        itemSprite.sprite = boxSlot.itemInfo.itemIcon;
        itemCount.text = boxSlot.currentAmount.ToString();
        itemSprite.color = Color.white;
    }

    private void Update()
    {
        if (assignedBoxSlot.itemInfo != null)
        {
            transform.position = Mouse.current.position.ReadValue();

            if (Mouse.current.leftButton.wasPressedThisFrame && !Is_Pointer_Over_UIObject())
            {
                Clear_Slot();
            }
        }
    }

    public void Clear_Slot()
    {
        assignedBoxSlot.Clear_Slot();
        itemCount.text = "";
        itemSprite.color = Color.clear;
        itemSprite.sprite = null;
    }

    public static bool Is_Pointer_Over_UIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Mouse.current.position.ReadValue();
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}