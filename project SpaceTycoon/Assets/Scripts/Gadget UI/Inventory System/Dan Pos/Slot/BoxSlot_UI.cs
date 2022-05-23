using UnityEngine;
using UnityEngine.UI;

public class BoxSlot_UI : MonoBehaviour
{
    [SerializeField] private Image _itemSprite;
    public Image itemSprite => _itemSprite;

    [SerializeField] private Text _itemCount;

    [SerializeField] private Box_Slot _assignedBoxSlot;
    public Box_Slot assignedBoxSlot => _assignedBoxSlot;

    private Button button;

    public Box_Display parentDisplay { get; private set; }

    private void Awake()
    {
        Clear_Slot();
        button = GetComponent<Button>();
        button?.onClick.AddListener(On_UISlot_Click);

        parentDisplay = transform.parent.GetComponent<Box_Display>();
    }

    private void Update()
    {
        Slot_Unlock_UI_Check();
    }

    public void Init(Box_Slot slot)
    {
        _assignedBoxSlot = slot;
        Update_UISlot(slot);
    }

    public void Update_UISlot(Box_Slot slot)
    {
        if (slot.itemInfo != null)
        {
            _itemSprite.sprite = slot.itemInfo.itemIcon;
            _itemSprite.color = Color.white;
            if (slot.currentAmount > 1) _itemCount.text = slot.currentAmount.ToString();
            else _itemCount.text = "";

        }
        else
        {
            Clear_Slot();
        }
    }

    public void Update_UISlot()
    {
        if (_assignedBoxSlot != null) Update_UISlot(_assignedBoxSlot);
    }

    public void Clear_Slot()
    {
        _assignedBoxSlot?.Clear_Slot();
        _itemSprite.sprite = null;
        _itemSprite.color = Color.clear;
        _itemCount.text = "";
    }

    public void On_UISlot_Click()
    {
        parentDisplay?.Slot_Clicked(this);
    }

    public static bool slotClicked = false;
    public void Slot_Clicked()
    {
        slotClicked = true;
        slotClicked = false;
    }

    public GameObject lockedImage;
    public void Slot_Unlock_UI_Check()
    {
        if (!_assignedBoxSlot.unlocked)
        {
            lockedImage.SetActive(true);
            button.enabled = false;
        }
        if (_assignedBoxSlot.unlocked)
        {
            lockedImage.SetActive(false);
            button.enabled = true;
        }
    }
}