using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePod_Closet_Panel : SpaceTycoon_Main_GameController
{
    private void Update()
    {
        Icon_Popup();
        Automatic_Exit();
        Unlock_Outfit();
    }

    public GameObject gameObject_closet;
    public EscapePod_Closet_MainController controller;

    public void TurnOff_All_Options()
    {
        controller.spaceSuitOptionPanel.SetActive(false);
        controller.pajamasOptionPanel.SetActive(false);
    }
    
    void Unlock_Outfit()
    {
        if (Player_Outfit.isSpaceSuitUnlocked)
        {
            controller.spaceSuitOptionButton.SetActive(false);
            controller.spaceSuitSelectButton.SetActive(true);
        }
        if (Player_Outfit.isPajamasUnlocked)
        {
            controller.pajamasOptionButton.SetActive(false);
            controller.pajamasSelectButton.SetActive(true);
        }
    }
    
    // icon
    void Icon_Popup()
    {
        // on
        if (controller.playerDetection && isPanelMenuOn == false)
        {
            controller.Icon.SetActive(true);
        }
        // off
        if (controller.playerDetection == false || isPanelMenuOn)
        {
            controller.Icon.SetActive(false);
        }
    }

    // icon pressed
    public void Icon_Pressed()
    {
        controller.mainPanel.SetActive(true);
        isPanelMenuOn = true;
    }

    // exit menu
    public void Manual_Exit()
    {
        controller.mainPanel.SetActive(false);
        isPanelMenuOn = false;
    }
    void Automatic_Exit()
    {
        if (controller.playerDetection == false && controller.mainPanel.activeSelf == true)
        {
            controller.mainPanel.SetActive(false);
            isPanelMenuOn = false;
        }
    }

    // dismantle
    public void Dismantle()
    {
        // closet_storage += 1;
        controller.iconBoxCollider.SetActive(false);
        Destroy(gameObject_closet);
    }


    // innerWear
    public void InnerWear_Select()
    {
        Player_Outfit.outfitNum = 1;
    }

    // spaceSuit
    public void SpaceSuit_Options()
    {
        TurnOff_All_Options();
        controller.spaceSuitOptionPanel.SetActive(true);
    }
    public void SpaceSuit_Craft()
    {
        // if player has all the ingredients
        TurnOff_All_Options();
        Player_Outfit.isSpaceSuitUnlocked = true;
    }
    public void SpaceSuit_Select()
    {
        Player_Outfit.outfitNum = 2;
    }

    // pajamas
    public void Pajamas_Options()
    {
        TurnOff_All_Options();
        controller.pajamasOptionPanel.SetActive(true);
    }
    public void Pajamas_Craft()
    {
        // if player has all the ingredients
        TurnOff_All_Options();
        Player_Outfit.isPajamasUnlocked = true;
    }
    public void Pajamas_Select()
    {
        Player_Outfit.outfitNum = 3;
    }
}
