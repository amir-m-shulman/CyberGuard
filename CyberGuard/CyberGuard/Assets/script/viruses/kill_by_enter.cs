using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_by_enter : MonoBehaviour
{
    [SerializeField] int enters_num;
    [SerializeField] GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        if(spawn_enemy.enters == enters_num) { Destroy(gameObject); p.transform.position = transform.position; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
