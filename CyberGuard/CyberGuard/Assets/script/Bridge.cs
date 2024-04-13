using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bridge : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] Light2D L;
    // Start is called before the first frame update
    void Start()
    {
        if(level <= spawn_enemy.enters)
        {
            L.color = Color.red;
            print("change bridge color!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
