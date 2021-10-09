using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theFalsePresence : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator anim;
    static public int theFalsePresenceMaxHealth = 100;
    static public int theFalsePresencecurrentHealth;
    Transform target;
    [SerializeField]
    float agroRange;
    [SerializeField]
    float moveSpeed;
    public static bool melee = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        theFalsePresencecurrentHealth = theFalsePresenceMaxHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // distance to player
        float distance = Vector2.Distance(transform.position, target.position);

        // agro and chase
        if (distance < agroRange)
        {
            movementChase();
            anim.SetBool("Walk", true);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            anim.SetBool("Walk", false);
        }

        void movementChase()
        {
            if (transform.position.x < target.position.x)
            {
                 // target is on the left so move right 
                 rb.velocity = new Vector2(moveSpeed, 0);
                 transform.localScale = new Vector2(1, 1);
            }
            else if (transform.position.x > target.position.x)
            {
                 // target is on the right so move left
                 rb.velocity = new Vector2(-moveSpeed, 0);
                 transform.localScale = new Vector2(-1, 1);
            }
        }
        
        // attack 
        if (melee)
        {
            anim.SetBool("Melee", true);
        }
        else
        {
            anim.SetBool("Melee", false);
        }
    }
    
    // theFalsePresence condition
    public void TakeDamage(int damage)
    {
        theFalsePresencecurrentHealth -= damage;
        anim.SetTrigger("Hurt");
        if(theFalsePresencecurrentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetBool("isDead", true);
        moveSpeed = 0f;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 6f);
    }
}
