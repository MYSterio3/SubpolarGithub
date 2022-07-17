using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "New Seed")]
public class Seed_ScrObj : ScriptableObject
{
    public int seedID;
    public Sprite[] sprites;
    // set min and max range around 5
    public int minFinishDays, maxFinishDays;
    public int seedBuyPrice, harvestSellPrice;
    // seed detail for tooltip
    public string seedName;
    [TextArea(5, 10)]
    public string seedDescription;
}
