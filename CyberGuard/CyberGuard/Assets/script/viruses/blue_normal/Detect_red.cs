using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_red : MonoBehaviour
{
    [SerializeField] string massege;
   // [SerializeField] stupid st;
    PlayerMovement pm;
    //stupid st;
    stupid st;

    
    // Start is called before the first frame update
    void Start()
    {
        if (spawn_enemy.enters == 0) { Destroy(this); }
        PlayerMovement pm = GetComponent<PlayerMovement>();
        st = gameObject.GetComponent<stupid>();
        
    }
    private void FixedUpdate()
    {

        // rays
        RaycastHit2D ray = Physics2D.Raycast(transform.position, -Vector2.up);
        Debug.DrawRay(transform.position, -Vector2.up, Color.red);

        


        if (ray.collider.CompareTag("red")  || (ray.collider.CompareTag("Player")))
        {
            stupid.WhereHit = massege;
            print("detect red!");
        }
        
        
    }

    
   /* private void OnTriggerStay2D(Collider2D collision)
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
   */


}
