using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_red : MonoBehaviour
{
    [SerializeField] string massege;
    [SerializeField] stupid st;
    PlayerMovement pm;
    
    // Start is called before the first frame update
    void Start()
    {
       // if (spawn_enemy.enters == 0) { Destroy(this); }
        PlayerMovement pm = GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("red"))
        {
            st.WhereHit = massege;
            print("collision with red!");
        }
    }
}
