using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool CanMove = true;

    [SerializeField] float moveSpeed = 7f;
    SpriteRenderer SR;

    float Vertical;
    float Horizontal;
    Vector2 pos;

    [SerializeField] Animator animator;

    [SerializeField] next_scene ns;

    [SerializeField] GameObject talk_text;

    Rigidbody2D rb;
    [SerializeField] GameObject LoseScreen;

    public static string enemy;
    //for fight
    public string control = "player";
    public bool PlayerTurn = true;
    public bool GoNpc = false;
    public int Mish = 1;
    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        pos = new Vector2(Horizontal * moveSpeed, Vertical * moveSpeed);
        //transform.position += pos;
        if(CanMove)
        {
            rb.velocity = pos;

        }

        if (Input.GetKey("a") )
        {
            animator.SetTrigger("normal");
            SR.flipX = true;
        }else if(Input.GetKey("d") )
        {
            animator.SetTrigger("normal");
            SR.flipX = false;
        }

        if(Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("d"))
        {
            SR.flipX = false;
            animator.SetTrigger("up");
        }
        if (Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d"))
        {
            SR.flipX = false;
            animator.SetTrigger("down");
        }





    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Respawn") && SceneManager.GetActiveScene().buildIndex != 1)
        {
            respawn();
        }
        else if(collision.CompareTag("Respawn"))
        {
            transform.position = new Vector2(0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("go to level one"))
        {
            ns.Next_level();
            print("go to level one!");

        }
        if(collision.gameObject.CompareTag("talk") && talk_text != null)
        {
            talk_text.SetActive(true);
        }
        if(collision.gameObject.CompareTag("blue virus"))
        {
            enemy = "blue virus";
        }
    }
    private void respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void lose()
    {
        LoseScreen.SetActive(true);
    }
}
