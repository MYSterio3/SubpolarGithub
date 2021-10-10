using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerPlayer : MonoBehaviour
{
    public SpriteRenderer sr;
    private Animator anim;
    private bool pickupAllow;
    private float m;
    private enum MovementState { hammerPlayerIdle, hammerPlayerWalk }
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // item pickup update
        if (pickupAllow && Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }

        // melee attack update and attack cool time
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                anim.SetTrigger("Melee");
                nextAttackTime = Time.time + 3f / attackRate;
            }
        }

        // player movement update
        m = Input.GetAxisRaw("Horizontal");


        // animation update
        updateAnim();
    }

    // movement animation
    private void updateAnim()
    {
        MovementState state;

        if (m > 0f)
        {
            state = MovementState.hammerPlayerWalk;
        }
        else if (m < 0f)
        {
            state = MovementState.hammerPlayerWalk;
        }
        else
        {
            state = MovementState.hammerPlayerIdle;
        }

        anim.SetInteger("state", (int)state);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // item pickup function
        if (collision.CompareTag("hammerBox"))
        {
            pickupAllow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("hammerBox"))
        {
            pickupAllow = false;
        }
    }

    private void Pickup()
    {
        this.sr.enabled = true;
        Destroy(GameObject.FindWithTag("swordPlayer"));
        Destroy(GameObject.FindWithTag("staffPlayer"));
    }

}
