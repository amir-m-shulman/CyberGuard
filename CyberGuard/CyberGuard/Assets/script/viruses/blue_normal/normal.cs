using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normal : MonoBehaviour
{
    PlayerMovement PM;
    Vector3 p;
    public bool once = false;
    private Animator a;
    private bool nomove = false;
    next_scene ns;
    public static string WhereHit;
    BoxCollider2D boxy;
    private bool onse;
    [SerializeField] GameObject down;
    // Start is called before the first frame update
    void Start()
    {
        GameObject p = GameObject.Find("Player");
        PM = p.GetComponent<PlayerMovement>();
        a = GetComponent<Animator>();
        ns = p.GetComponent<next_scene>();
        boxy = gameObject.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (PM.GoNpc)
        {
            if (once)
            {
                
                if (WhereHit != "RedDown")
                {
                    p = new Vector3(transform.position.x, transform.position.y - 4, transform.position.z);
                }
                else { p = new Vector3(transform.position.x + 2, transform.position.y - 2, transform.position.z); }
                once = false;
                // WhereHit = "none";
            }


            if (transform.position != p && !nomove)
            {
                transform.position = Vector2.MoveTowards(transform.position, p, 15 * Time.deltaTime);
            }
            else
            {
                Invoke("moveplayer", 0.5f); PM.GoNpc = false; once = true; boxy.enabled = true; WhereHit = "";
            }



        }
        else { once = true; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("red"))
        {
            die();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            PM.lose();
        }
        if (collision.gameObject.CompareTag("blue"))
        {
            collision.gameObject.GetComponent<Button>().NoRed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("blue"))
        {
            collision.gameObject.GetComponent<Button>().NoRed = false;
        }
    }
    private void moveplayer()
    {
        PM.PlayerTurn = true;
    }
    private void die()
    {
        if (!onse)
        {
            nomove = true;
            a.SetTrigger("die");
            spawn_enemy.enters += 1;
            print(spawn_enemy.enters);
            Invoke("dt", 1);
            onse = true;
        }

    }
    private void dt()
    {
        ns.Next_level();
    }
}
