using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePod_Closet_MainController : MonoBehaviour
{
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    Animator anim;
    
    [HideInInspector]
    public bool playerDetection;

    public Player_MainController playerController;

    public GameObject icon, iconBoxCollider, mainPanel;

    // innerWear
    public GameObject innerWearOption, innerWearSelectButton;

    // spaceSuit
    public GameObject spaceSuitOption, spaceSuitSelectButton, spaceSuitCraftButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player_hand"))
        {
            playerDetection = true;
            anim.SetBool("playerDetected", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player_hand"))
        {
            playerDetection = false;
            anim.SetBool("playerDetected", false);
        }
    }
}
