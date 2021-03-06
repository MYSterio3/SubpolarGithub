using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerForMobile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    
    // if change platform, go to pauseController and change reference to Player audio for pause and resume sound stop
    public static AudioSource audioSRC;
    
    Vector2 move;
    public float moveSpeed;
    public float maxSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSRC = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {   
        //Move
        move = gameObject.transform.position;
        if(moveSpeed < maxSpeed)
        {
            moveSpeed += 0.00005f * Time.deltaTime;
        }
        move.x += moveSpeed;
        gameObject.transform.position = move;

        //for GroundCheck
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (!audioSRC.isPlaying && isGrounded)
        {
            audioSRC.Play();
        }
        else if (audioSRC.isPlaying && isGrounded == false)
        {
            audioSRC.Stop();
        }
    }

    //Drop
    public Transform dropPoint;
    public GameObject[] presents;
    int randomInt;
    float dropRate = 2f;
    float nextDropTime = 0f;
    
    public void Drop()
    {
        if (Time.time > nextDropTime)
        {
            FindObjectOfType<audioManager>().Play("PlayerThrow");
            randomInt = Random.Range(0, presents.Length);
            Instantiate(presents[randomInt], dropPoint.position, dropPoint.rotation);
            nextDropTime = Time.time + 1f / dropRate;
        }
    }

    //Jump
    public float jumphight;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    public void Jump()
    {
        FindObjectOfType<audioManager>().Play("PlayerJump");
        
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumphight);
        }
    }

    //Slide
    public void Slide()
    {
        FindObjectOfType<audioManager>().Play("PlayerSlide");
        anim.SetTrigger("slide");
    }

    //pause
    void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.GamePlay;
    }

    //GameOver
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("destroyBox"))
        {
            audioSRC.Pause();
            gameOverMenu.gameOver = true;
            scoreManager.GameOver();
            coinText.coinSave();
            scoreManager.highscoreSave();
            //moving top right UI to gameOverMenu 
            Destroy(GameObject.FindWithTag("scoreUI"));
        }
    }
}
