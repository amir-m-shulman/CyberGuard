using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f;
    SpriteRenderer SR;

    float Vertical;
    float Horizontal;
    Vector3 pos;

    [SerializeField] Animator animator;

    [SerializeField] next_scene ns;
    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        pos = new Vector3(Horizontal * moveSpeed, Vertical * moveSpeed, 0);
        transform.position += pos;

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
    }
    private void respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
