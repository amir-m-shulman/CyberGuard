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
    LayerMask l;
    RaycastHit2D ray;

    
    // Start is called before the first frame update
    void Start()
    {
        //if (spawn_enemy.enters == 0) { Destroy(this); }
        pm = FindObjectOfType<PlayerMovement>();
        st = GetComponentInParent<stupid>();
        l = LayerMask.GetMask("red");
        st = GetComponentInParent<stupid>();


    }
    private void FixedUpdate()
    {
        // rays
        
        if (!pm.GoNpc)
        {
            ray = Physics2D.Raycast(transform.position, -Vector2.up, 3, l);
            Debug.DrawRay(transform.position, -Vector2.up * 3, Color.red);

        }

        

        if(ray.collider != null)
        {
            if (ray.collider.CompareTag("red") || (ray.collider.CompareTag("Player")))
            {
                st.WhereHit = massege;
                
            }
            
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
