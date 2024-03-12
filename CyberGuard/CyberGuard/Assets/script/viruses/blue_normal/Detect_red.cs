using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_red : MonoBehaviour
{
    [SerializeField] string massege;
   // [SerializeField] stupid st;
    PlayerMovement pm;
    //stupid st;
    private int i;
    
    // Start is called before the first frame update
    void Start()
    {
        if (spawn_enemy.enters == 0) { Destroy(this); }
        PlayerMovement pm = GetComponent<PlayerMovement>();
        stupid st = gameObject.GetComponent<stupid>();
        
    }
    private void FixedUpdate()
    {
        i += 1;
        if(i % 2 ==0)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
        }
        else{ transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f); }
    }

    // Update is called once per frame

    

    //private void OnTriggerEnter2D(Collider2D collision)
    // {
    //   if (collision.CompareTag("red"))
    //  {
    //      stupid.WhereHit = massege;
    //      print("collision with red!");
    // }
    //}
   /* private void OnTriggerStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("red") || collision.gameObject.CompareTag("Player"))
        {
            stupid.WhereHit = massege;
            print("collision with red!");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("red") || collision.gameObject.CompareTag("Player"))
        {
            stupid.WhereHit = "none";
            print("collision with red!");
        }
        
    }
   */
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("red") || collision.gameObject.CompareTag("Player"))
        {
            stupid.WhereHit = massege;
            print("collision with red!");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("red") || collision.gameObject.CompareTag("Player"))
        {
            stupid.WhereHit = "none";
            print("collision with red!");
        }
    }


}
