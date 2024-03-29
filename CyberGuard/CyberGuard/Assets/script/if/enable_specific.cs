using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enable_specific : MonoBehaviour
{
    [SerializeField] int enters_num;
    [SerializeField] GameObject[] destroy_together;
    // Start is called before the first frame update
    void Start()
    {
        if (spawn_enemy.enters == enters_num)
        {
           
            foreach (GameObject c in destroy_together)
            {
                c.SetActive(true);
            }
            
        }
    }
}

    // Update is called once per frame
    

