using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class second_object_controller : MonoBehaviour
{
    public GameObject melee;

    /// Ingredients///////////////////////////////////////////////////////////////////////
    public GameObject fireBall;
    bool fireBall_scanner;

    public GameObject iceBall;
    bool iceBall_scanner;

    public GameObject cane;
    bool cane_scanner;

    public GameObject spear;
    bool spear_scanner;

    /// Items///////////////////////////////////////////////////////////////////////
    public GameObject fireStaff;
    bool fireStaff_scanner;

    public GameObject fireSpear;
    bool fireSpear_scanner;

    public GameObject iceStaff;
    bool iceStaff_scanner;

    public GameObject iceSpear;
    bool iceSpear_scanner;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        PickUp();
        TurnOn_Hand1();
    }

    public GameObject hand1;
    void TurnOn_Hand1()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            hand1.SetActive(true);
            TurnOff_Itself();
        }
    }
    void TurnOff_Itself()
    {
        gameObject.SetActive(false);
    }

    void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            /// Ingredients///////////////////////////////////////////////////////////////////////
            if (fireBall_scanner == true)
            {
                fireBall.SetActive(true);
                fireBall_scanner = false;
            }

            if (iceBall_scanner == true)
            {
                iceBall.SetActive(true);
                iceBall_scanner = false;
            }

            if (cane_scanner == true)
            {
                cane.SetActive(true);
                cane_scanner = false;
            }

            if (spear_scanner == true)
            {
                spear.SetActive(true);
                spear_scanner = false;
            }

            /// Items///////////////////////////////////////////////////////////////////////
            if (fireStaff_scanner == true)
            {
                fireStaff.SetActive(true);
                fireStaff_scanner = false;
            }

            if (fireSpear_scanner == true)
            {
                fireSpear.SetActive(true);
                fireSpear_scanner = false;
            }

            if (iceStaff_scanner == true)
            {
                iceStaff.SetActive(true);
                iceStaff_scanner = false;
            }

            if (iceSpear_scanner == true)
            {
                iceSpear.SetActive(true);
                iceSpear_scanner = false;
            }
        }
    }

    // scanner /////////////////////////////////////////////////////////
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("fireBall"))
        {
            fireBall_scanner = true;
        }
        if (collision.CompareTag("iceBall"))
        {
            iceBall_scanner = true;
        }
        if (collision.CompareTag("cane"))
        {
            cane_scanner = true;
        }
        if (collision.CompareTag("spear"))
        {
            spear_scanner = true;
        }
        if (collision.CompareTag("fireStaff"))
        {
            fireStaff_scanner = true;
        }
        if (collision.CompareTag("fireSpear"))
        {
            fireSpear_scanner = true;
        }
        if (collision.CompareTag("iceStaff"))
        {
            iceStaff_scanner = true;
        }
        if (collision.CompareTag("iceSpear"))
        {
            iceSpear_scanner = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("fireBall"))
        {
            fireBall_scanner = false;
        }
        if (collision.CompareTag("iceBall"))
        {
            iceBall_scanner = false;
        }
        if (collision.CompareTag("cane"))
        {
            cane_scanner = false;
        }
        if (collision.CompareTag("spear"))
        {
            spear_scanner = false;
        }
        if (collision.CompareTag("fireStaff"))
        {
            fireStaff_scanner = false;
        }
        if (collision.CompareTag("fireSpear"))
        {
            fireSpear_scanner = false;
        }
        if (collision.CompareTag("iceStaff"))
        {
            iceStaff_scanner = false;
        }
        if (collision.CompareTag("iceSpear"))
        {
            iceSpear_scanner = false;
        }
    }
}