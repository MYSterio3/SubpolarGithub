using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairBed : MonoBehaviour
{
    SpaceTycoon_Main_GameController controller;
    Player_MainController player;
    public Object_ScrObj objectInfo;

    bool playerDetection;

    bool facingLeft = false;

    public Icon icon;
    public GameObject mainPanel;

    public GameObject[] rotateButtons;
    public GameObject[] modeButtons;
    public GameObject[] playerActionButtons;
    
    public Transform[] sitSleepTransforms;

    SpriteRenderer sr;
    public Sprite[] chairBedSprites;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("SpaceTycoon Main GameController").GetComponent<SpaceTycoon_Main_GameController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_MainController>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ChangeTo_Chair();
        rotateButtons[0].SetActive(false);
    }

    private void Update()
    {
        controller.Icon_Popup_UpdateCheck(playerDetection, icon.gameObject);
        controller.Automatic_TurnOff_ObjectPanel(playerDetection, mainPanel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player_hand"))
        {
            playerDetection = true;
            icon.Set_Icon_Position();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player_hand"))
        {
            playerDetection = false;
            icon.Set_Icon_to_Default_Position();
        }
    }

    // Basic Functions
    public void Open_MainPanel()
    {
        controller.Icon_Pressed(mainPanel);
    }
    public void Exit_MainPanel()
    {
        controller.Manual_TurnOff_ObjectPanel(mainPanel);
    }

    public void Dismantle()
    {
        controller.Object_Dismantle(objectInfo, 1, icon, gameObject);
    }

    // ChairBed Functions
    public void ChangeTo_Bed()
    {
        sr.sprite = chairBedSprites[1];
        playerActionButtons[0].SetActive(false);
        playerActionButtons[1].SetActive(true);
    }
    public void ChangeTo_Chair() 
    {
        sr.sprite = chairBedSprites[0];
        playerActionButtons[0].SetActive(true);
        playerActionButtons[1].SetActive(false);
    }

    public void Rotate_Right()
    {
        facingLeft = !facingLeft;
        gameObject.transform.Rotate(0, 180, 0);
        rotateButtons[0].SetActive(false);
        rotateButtons[1].SetActive(true);
    }
    public void Rotate_Left()
    {
        facingLeft = !facingLeft;
        gameObject.transform.Rotate(0, 180, 0);
        rotateButtons[0].SetActive(true);
        rotateButtons[1].SetActive(false);
    }
}