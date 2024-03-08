using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_by_enter : MonoBehaviour
{
    [SerializeField] int enters_num;
    // Start is called before the first frame update
    void Start()
    {
        if(spawn_enemy.enters > enters_num) { Destroy(this); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
