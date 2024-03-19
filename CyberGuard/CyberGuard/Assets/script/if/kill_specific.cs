using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_specific : MonoBehaviour
{
    [SerializeField] int enters_num;
    [SerializeField] GameObject p;
    [SerializeField] GameObject[] destroy_together;
    // Start is called before the first frame update
    void Start()
    {
        if(spawn_enemy.enters == enters_num) 
        {
            foreach (GameObject c in destroy_together)
            {
                Destroy(c);
            }
            if(p != null)
            {
                p.transform.position = transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
