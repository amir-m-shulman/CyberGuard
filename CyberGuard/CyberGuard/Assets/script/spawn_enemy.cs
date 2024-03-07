using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemy : MonoBehaviour
{
    GameObject virus;
    [SerializeField] GameObject BV;
    [SerializeField] PlayerMovement PM;
    public static int enters;
    
    // Start is called before the first frame update
    void Start()
    {
        if(enters == 0)
        {
            PlayerMovement.enemy = "blue virus";
        }
        
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
