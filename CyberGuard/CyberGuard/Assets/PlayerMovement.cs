using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f;
    SpriteRenderer SR;

    float Vertical;
    float Horizontal;
    Vector3 pos;

    [SerializeField] Animator animator;
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

        if (Input.GetKey("a") && !Input.GetKey("w") && !Input.GetKey("s"))
        {
            animator.SetTrigger("normal");
            SR.flipX = true;
        }else if(Input.GetKey("d") && !Input.GetKey("w") && !Input.GetKey("s"))
        {
            animator.SetTrigger("normal");
            SR.flipX = false;
        }

        if(Input.GetKey("w"))
        {
            SR.flipX = false;
            animator.SetTrigger("up");
        }
        if (Input.GetKey("s"))
        {
            SR.flipX = false;
            animator.SetTrigger("down");
        }





    }
}
