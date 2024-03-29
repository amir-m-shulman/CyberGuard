using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_time : MonoBehaviour
{
    [SerializeField] int maxtime;
    [SerializeField] GameObject[] destroy_together;
    [SerializeField] GameObject above;
    float i;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        i += Time.deltaTime;

        if (i >= maxtime)
        {
            
            foreach (GameObject c in destroy_together)
            {
                Destroy(c);
            }

        }
    }
}
