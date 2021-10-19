using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordPlayer : MonoBehaviour
{
    public SpriteRenderer sr;
    public Animator anim;
    private bool pickupAllow;
    private float m;
    private enum MovementState { swordPlayerIdle, swordPlayerWalk }
    float attackRate = 2f;
    float nextAttackTime = 0f;

    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
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
                nextAttackTime = Time.time + 2f / attackRate;   // melee cool time
            }
        }
     
        // player movement update
        m = Input.GetAxisRaw("Horizontal");

        // animation update
        updateAnim();
    }

    // Movement animation
    private void updateAnim()
    {
        MovementState state;
        
        if (m > 0f)
        {
            state = MovementState.swordPlayerWalk;
        }    
        else if (m < 0f)
        {
            state = MovementState.swordPlayerWalk;
        }
        else
        {
            state = MovementState.swordPlayerIdle;
        }
        
        anim.SetInteger("state", (int)state);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Item Pickup function 
        if (collision.CompareTag("swordBox"))
        {
            pickupAllow = true;
        }

        // hurt animation
        if (collision.CompareTag("enemyknockbackBox"))
        {
            anim.SetTrigger("Hurt");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("swordBox"))
        {
            pickupAllow = false;
        }
    }

    private void Pickup()
    {
        this.sr.enabled = true;
        Destroy(GameObject.FindWithTag("staffPlayer"));
        Destroy(GameObject.FindWithTag("hammerPlayer"));
    }
}