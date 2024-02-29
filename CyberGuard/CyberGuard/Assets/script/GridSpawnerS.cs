using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawnerS : MonoBehaviour
{
    [SerializeField] GameObject square;
    [SerializeField] GameObject squaret;
    [SerializeField] GameObject dad;
    Vector2 pos;
    Vector2 spos;
    // Start is called before the first frame update
    void Start()
    {   
        pos = square.transform.position;
        spos = pos;
        for (int i = 1; i <= 10; i ++)
        {
            if(i % 2 == 0)
            {
                GameObject c = Instantiate(square);
                pos.x += 2.15f;
                c.transform.position = pos;
                c.transform.parent = dad.transform;
            }
            else
            {
                GameObject c = Instantiate(squaret);
                pos.x += 2.15f;
                c.transform.position = pos;
                c.transform.parent = dad.transform;

            }

        }
        pos = spos;
        for (int i = 0 ; i < 6 ; i++)
        {
            pos.y += 2.15f;
            GameObject d = Instantiate(dad);
            d.transform.position = pos;
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
