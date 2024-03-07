using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemy : MonoBehaviour
{
    GameObject virus;
    [SerializeField] GameObject BV;
    [SerializeField] PlayerMovement PM;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerMovement.enemy == "blue virus")
        {
            virus = Instantiate(BV);
        }
        PM.CanMove = false;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
