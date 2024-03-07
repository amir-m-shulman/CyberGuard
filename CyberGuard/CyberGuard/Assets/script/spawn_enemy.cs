using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemy : MonoBehaviour
{
    GameObject virus;
    [SerializeField] GameObject SBV;
    [SerializeField] PlayerMovement PM;
    public static int enters;
    
    // Start is called before the first frame update
    void Start()
    {
        if(enters == 0)
        {
            PlayerMovement.enemy = "stupid blue virus";
        }
        
        if(PlayerMovement.enemy == "stupid blue virus")
        {
            virus = Instantiate(SBV);
            virus.transform.position = new Vector2(-6, 10);
        }
        PM.CanMove = false;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
