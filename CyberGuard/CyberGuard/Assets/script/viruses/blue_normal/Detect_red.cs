using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_red : MonoBehaviour
{
    [SerializeField] string massege;
    stupid st;
    PlayerMovement pm;
    
    // Start is called before the first frame update
    void Start()
    {
        if (spawn_enemy.enters == 0) { Destroy(this); }
        stupid st = GetComponent<stupid>();
        PlayerMovement pm = GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("red") && pm.GoNpc)
        {
            st.WhereHit = massege;
        }
    }
}
