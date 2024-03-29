using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [SerializeField] TextMeshPro ExtraTurnsTxt;
    int extraturns;
    RaycastHit2D Rray;
    LayerMask l;
    [Header("masseges")] 
    [SerializeField] string Downmassege;

    [Header("ray points")]
    [SerializeField] GameObject down;

    // Start is called before the first frame update
    void Start()
    {
        extraturns = 3;
        ExtraTurnsTxt.text = "3";
        
        GameObject p = GameObject.Find("Player");
        PM = p.GetComponent<PlayerMovement>();
        a = GetComponent<Animator>();
        ns = p.GetComponent<next_scene>();
        boxy = gameObject.GetComponent<BoxCollider2D>();
        l = LayerMask.GetMask("red");


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
                    p = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
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

        //rays

        if (!PM.GoNpc)
        {
            Rray = Physics2D.Raycast(transform.position, -Vector2.up, 3, l);
            Debug.DrawRay(transform.position, -Vector2.up * 3, Color.red);
            print("draw ray");
        }



        if (Rray.collider != null)
        {
            if (Rray.collider.CompareTag("red") || (Rray.collider.CompareTag("Player")))
            {
                stupid.WhereHit = Downmassege;
                print("detect red!");
            }

        }
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
