using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stupid : MonoBehaviour
{
    [SerializeField] PlayerMovement PM;
    Vector3 p;
    private bool once = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PM.GoNpc)
        {
            if (once) 
            {
                p = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
                once = false;
            }
            

            if(transform.position != p)
            {
                transform.position = Vector2.MoveTowards(transform.position, p, 15 * Time.deltaTime);
            }
            else {Invoke("moveplayer",0.5f); PM.GoNpc = false; once = true;}
            
            

        }
        else { once = true; }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            die();
        }
    }
    private IEnumerator Move()
    {
       
        return null;
    }
    private void moveplayer()
    {
        PM.PlayerTurn = true;
    }
    private void die()
    {
        print("die virus!");
    }
}