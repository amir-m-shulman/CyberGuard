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
    
    int random;
    GameObject pl;
    // thinking stuff
    float Xdistance;
    float Ydistance;

    // Start is called before the first frame update
    void Start()
    {
        extraturns = 3;
        ExtraTurnsTxt.text = "3";
        
        pl = GameObject.Find("Player");
        PM = pl.GetComponent<PlayerMovement>();
        a = GetComponent<Animator>();
        ns = pl.GetComponent<next_scene>();
        boxy = gameObject.GetComponent<BoxCollider2D>();
        l = LayerMask.GetMask("red");

        // decide spawn area
        random = Random.Range(0, 9);
        switch(random)
        {
            case 0:
                transform.position = new Vector2(-8, 10);
                break;
            case 1:
                transform.position = new Vector2(-6, 10);
                break;
            case 2:
                transform.position = new Vector2(-4, 10);
                break;
            case 3:
                transform.position = new Vector2(-2, 10);
                break;
            case 4:
                transform.position = new Vector2(0, 10);
                break;
            case 5:
                transform.position = new Vector2(2, 10);
                break;
            case 6:
                transform.position = new Vector2(4, 10);
                break;
            case 7:
                transform.position = new Vector2(6, 10);
                break;
            case 8:
                transform.position = new Vector2(8, 10);
                break;
            
        }
        stupid.WhereHit = "";


    }

    // Update is called once per frame
    void Update()
    {
        if (PM.GoNpc)
        {
            // decide what turn to take
            if (once)
            {
                //calculate distance x
                if(transform.position.x >= 0 && pl.transform.position.x <= 0 || transform.position.x <= 0 && pl.transform.position.x >= 0)
                {
                    Xdistance = Mathf.Abs(transform.position.x) + Mathf.Abs(pl.transform.position.x);
                }
                else if(transform.position.x < 0 && pl.transform.position.x < 0 )
                {
                    Xdistance = Mathf.Abs(transform.position.x) - Mathf.Abs(pl.transform.position.x);
                }
                else
                {
                    Xdistance = transform.position.x - pl.transform.position.x;
                }
                // calculate distance y
                if (transform.position.y >= 0 && pl.transform.position.y <= 0 || transform.position.y <= 0 && pl.transform.position.y >= 0)
                {
                    Ydistance = Mathf.Abs(transform.position.y) + Mathf.Abs(pl.transform.position.y);
                }
                else if (transform.position.y < 0 && pl.transform.position.y < 0)
                {
                    Ydistance = Mathf.Abs(transform.position.y) - Mathf.Abs(pl.transform.position.y);
                }
                else
                {
                    Ydistance = transform.position.y - pl.transform.position.y;
                }
                // in case the virus is not in immidiate danger
                if(stupid.WhereHit == "" && Mathf.Abs(Ydistance) >= 6)
                {
                    if(Mathf.Abs(Xdistance) > 2)
                    {
                        move("down");
                    }
                    else if (Xdistance >= 0)
                    {
                        random = Random.Range(1, 4);
                        if (random != 3) { move("down left"); }
                        else
                        {
                            random = Random.Range(1, 5);
                            if (random == 2) { move("down right"); }
                            else
                            {
                                move("down");
                            }

                        }
                    }
                    else
                    {
                        random = Random.Range(1, 4);
                        if (random != 3) { move("down right"); }
                        else
                        {
                            random = Random.Range(1, 5);
                            if (random == 2) { move("down left"); }
                            else
                            {
                                move("down");
                            }

                        }
                    }
                }

                //at the end of everything
                once = false;




            }

            // check that the bot moved and confirm
            if (transform.position != p && !nomove)
            {
                transform.position = Vector2.MoveTowards(transform.position, p, 15 * Time.deltaTime);
                print(p);
                print(stupid.WhereHit);
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

    private void move(string direction)
    {
        switch (direction)
        {
            case "down":
                p = new Vector2(transform.position.x, transform.position.y - 2);
                break;
            case "up":
                p = new Vector2(transform.position.x, transform.position.y + 2);
                break;
            case "left":
                p = new Vector2(transform.position.x - 2, transform.position.y);
                break;
            case "right":
                p = new Vector2(transform.position.x + 2, transform.position.y);
                break;
            case "up right":
                p = new Vector2(transform.position.x + 2, transform.position.y + 2);
                break;
            case "up left":
                p = new Vector2(transform.position.x - 2, transform.position.y + 2);
                break;
            case "down right":
                p = new Vector2(transform.position.x - 2, transform.position.y + 2);
                break;
            case "down left":
                p = new Vector2(transform.position.x - 2, transform.position.y - 2);
                break;
        }
    }
}
