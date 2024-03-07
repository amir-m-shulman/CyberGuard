using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fight : MonoBehaviour
{
    [SerializeField] PlayerMovement PM;
    private bool once;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!PM.PlayerTurn && once)
        {
            Move();
            once = false;
        }
        else { once = true; }
    }
    private void Move()
    {
        
    }
}
