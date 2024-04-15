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
    [SerializeField] BoxCollider2D boxy;
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
    public List<string> masseges = new();

    bool ThereAreMassages;
    float max;
    float max2;

    DummyBN bn;

    // Start is called before the first frame update
    void Start()
    {
        extraturns = 3;
        ExtraTurnsTxt.text = "3";
        
        pl = GameObject.Find("Player");
        PM = pl.GetComponent<PlayerMovement>();
        a = GetComponent<Animator>();
        ns = pl.GetComponent<next_scene>();
        bn = FindObjectOfType<DummyBN>();

        l = LayerMask.GetMask("red");
        print(masseges.Count);

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


    }

    // Update is called once per frame
    void Update()
    {
       
        if (PM.GoNpc)
        {
            // decide what turn to take
            if (once)
            {

                bn.Movedummy();
                // disable collider
                boxy.enabled = false;
                if (bn.CanCalculate)
                {
                    //check the best move
                    for (int i = 15; i >= 8; i--)
                    {
                        print("calculating best move!!");

                        if (max < bn.StateScore[i] + bn.StateScore[i - 8])
                        {
                            max = bn.StateScore[i];
                            max2 = i;
                        }
                    }
                    if (max2 > 7) { max2 -= 8; }

                    //do the move
                    switch (max2)
                    {
                        case 0:
                            print("best move is down");
                            move("down");
                            break;
                        case 1:
                            move("up");
                            break;
                        case 2:
                            move("left");
                            break;
                        case 3:
                            move("right");
                            break;
                        case 4:
                            move("up right");
                            break;
                        case 5:
                            move("up left");
                            break;
                        case 6:
                            move("down right");
                            break;
                        case 7:
                            move("down left");
                            break;
                    }
                }
               
                /*
                // see if there are any massages
                for (int i = 0; i != masseges.Count; i++)
                {
                     if(masseges[i] != "")
                    {
                        ThereAreMassages = true;
                    }
                }
                //calculate distance x
                if (transform.position.x >= 0 && pl.transform.position.x <= 0 || transform.position.x <= 0 && pl.transform.position.x >= 0)
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
                print(ThereAreMassages);
                // if the player is far from the virus and there is not a red block
                if(!ThereAreMassages && Mathf.Abs(Ydistance) >= 6)
                {
                    if(Mathf.Abs(Xdistance) > 2)
                    {
                        move("down");
                    }
                    else if (Xdistance >= 0)
                    {
                        random = Random.Range(1, 4);
                        if (random != 3 && transform.position.x != -8) { move("down left"); }
                        else
                        {
                            random = Random.Range(1, 5);
                            if (random == 2 && transform.position.x != 8) { move("down right"); }
                            else
                            {
                                move("down");
                            }

                        }
                    }
                    else
                    {
                        random = Random.Range(1, 4);
                        if (random != 3 && transform.position.x != -8) { move("down right"); }
                        else
                        {
                            random = Random.Range(1, 5);
                            if (random == 2 && transform.position.x != 8) { move("down left"); }
                            else
                            {
                                move("down");
                            }

                        }
                    }
                }
                // if there is a red block but the player is far from the virus 
                else if(Mathf.Abs(Ydistance) >= 6 && ThereAreMassages)
                {
                    random = Random.Range(1, 6);
                    if (masseges[7] != "down left" && masseges[6] != "down right")
                    {
                        if (Xdistance >= 0 && transform.position.x != -8 && random != 4) { move("down left"); }
                        else if(transform.position.x != 8) { move("down right"); }
                        print("nothing to do 5");
                    }
                    else if(masseges[7] == "down left")
                    {
                        if(Xdistance > 0 && random != 3 && transform.position.x != 8) { move("down right"); }
                        else { move("down"); }
                    }
                    else if (masseges[6] == "down right")
                    {
                        if (Xdistance > 0 && random != 2 && transform.position.x != -8) { move("down left"); }
                        else { move("down"); }
                    }


                }
                // if the player is close but there is no immidiate danger
                else if(Mathf.Abs(Ydistance) < 6 && !ThereAreMassages)
                {
                    
                    if(Mathf.Abs(Xdistance) > 6)
                    {
                        random = Random.Range(0, 6);
                        if (Xdistance > 0) 
                        {
                            if (transform.position.x != -8) { move("down left"); }
                            else if (random != 3) { move("down"); }
                            else { move("up"); }
                        }
                        else if(Xdistance < 0)
                        {
                            if (transform.position.x != 8) { move("down right"); }
                            else if(random != 2) { move("down"); }
                            else if(transform.position.y < 10) { move("up"); }
                        }
                       
                    }
                    else
                    {
                        random = Random.Range(0, 5);
                        if (Xdistance > 0)
                        {
                            if (transform.position.x != -8 && Ydistance != 2 && random != 4) { move("down left"); }
                            else if (Ydistance != 2 && random != 4) { move("down"); }
                            else if (transform.position.x != -8 && random != 2 && transform.position.y < 10) { move("up left"); }
                            else { move("up"); }
                        }
                        else if (Xdistance < 0)
                        {
                            if (transform.position.x != 8 && Ydistance != 2 && random != 4) { move("down right"); }
                            else if (Ydistance != 2 && random != 4) { move("down"); }
                            else if (transform.position.x != 8 && random != 2 && transform.position.y < 10) { move("up right"); }
                            else if(transform.position.y < 10) { move("up"); }
                        }
                    }
                    
                }
                // if the player is close and there is red
                else
                {
                    random = Random.Range(0, 5);
                    if (Xdistance > 0)
                    {
                        if (transform.position.x != -8 && Ydistance != 2 && random != 4 && masseges[7] != "down left") { move("down left"); }
                        else if (Ydistance != 2 && random != 4 && masseges[0] != "down") { move("down"); }
                        else if (transform.position.x != -8 && random != 2 && masseges[5] != "up left" && transform.position.y < 10) { move("up left"); }
                        else if (masseges[1] != "up" && transform.position.y < 10) { move("up"); }
                        else if (masseges[3] != "left" && transform.position.x != -8) { move("left");}
                        else { print("nothing to do 1"); }
                    }
                    else if (Xdistance <= 0)
                    {
                        if (transform.position.x != 8 && Ydistance != 2 && random != 4 && masseges[6] != "down right") { move("down right"); }
                        else if (Ydistance != 2 && random != 4 && masseges[0] != "down") { move("down"); }
                        else if (transform.position.x != 8 && random != 2 && masseges[4] != "up right" && transform.position.y < 10) { move("up right"); }
                        else if (masseges[1] != "up" && transform.position.y < 10) { move("up"); }
                        else if (masseges[4] != "right" && transform.position.x != 8) { move("right"); }
                        else { print("nothing to do 2"); }
                    }
                   
                }
            */

                //at the end of everything
                once = false;




            }

            // check that the bot moved and confirm
            if (transform.position != p && !nomove)
            {
                transform.position = Vector2.MoveTowards(transform.position, p, 15 * Time.deltaTime);
                print(p);
            }
            else
            {
                Invoke("moveplayer", 0.5f); 
                PM.GoNpc = false; 
                once = true; 
                boxy.enabled = true;
                ThereAreMassages = false;
                max = 0;
                max2 = 0;
                //reset all masseges
                for (int i = 0; i != masseges.Count; i++)
                {
                    masseges[i] = "";
                }
                print("reset!");
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
                p = new Vector2(transform.position.x + 2, transform.position.y - 2);
                break;
            case "down left":
                p = new Vector2(transform.position.x - 2, transform.position.y - 2);
                break;
        }
    }
}
