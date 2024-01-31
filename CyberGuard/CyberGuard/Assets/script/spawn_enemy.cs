using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemy : MonoBehaviour
{
    GameObject virus;
    [SerializeField] GameObject BV;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerMovement.enemy == "blue virus")
        {
            virus = Instantiate(BV) as GameObject;
        }
        virus.SetActive(true);

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
