using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyP_BN : MonoBehaviour
{
    private float[] StateScore = { 0, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0};
    [SerializeField] GameObject virus;
    DummyBN BN;
    private float Xdistance;
    public bool CanContinue = true;
    float max;
    GameObject Player;
    private float[] nisooy = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };






    // Start is called before the first frame update
    void Start()
    {
        //if (spawn_enemy.enters == 0) { Destroy(this); }
        BN = FindObjectOfType<DummyBN>();
        Player = GameObject.FindGameObjectWithTag("Player");



    }

    public void CalculateState(int d)
    {
        CanContinue = false;
        for (int i = 0; i < 16; i++)
        {
            transform.position = Player.transform.position;
            switch (i)
            {

                case 0:
                    transform.position = new Vector2(transform.position.x, transform.position.y - 2);
                    //calculate score
                    if (virus.transform.position.y < 0) { StateScore[i] = 1000; }
                    else if (transform.position.y > 10 || transform.position.x > 8 || transform.position.x < -8)
                    {
                        StateScore[i] = -1000;
                    }
                    else if (virus.transform.position == transform.position)
                    {
                        StateScore[i] = -1000;
                    }
                    else
                    {
                        StateScore[i] = 100;
                        StateScore[i] -= transform.position.y;
                        //calculate x distance
                        if (transform.position.x >= 0 && virus.transform.position.x <= 0 || transform.position.x <= 0 && virus.transform.position.x >= 0)
                        {
                            Xdistance = Mathf.Abs(transform.position.x) + Mathf.Abs(virus.transform.position.x);
                        }
                        else if (transform.position.x < 0 && virus.transform.position.x < 0)
                        {
                            Xdistance = Mathf.Abs(virus.transform.position.x) - Mathf.Abs(transform.position.x);
                        }
                        else
                        {
                            Xdistance = virus.transform.position.x - transform.position.x;
                        }
                        //continue to calculate the score
                        StateScore[i] += Mathf.Abs(Xdistance);
                        //if there is red next to the virus
                        for (int o = 0; o < 8; o++)
                        {
                            if (BN.collide[o] != "") { StateScore[i] -= 1; }

                        }




                    }


                    break;
                case 2:
                    transform.position = new Vector2(transform.position.x, transform.position.y + 2);
                    //calculate score
                    if (virus.transform.position.y < 0) { StateScore[i] = 1000; }
                    else if (transform.position.y > 10 || transform.position.x > 8 || transform.position.x < -8)
                    {
                        StateScore[i] = -1000;
                    }
                    else if (virus.transform.position == transform.position)
                    {
                        StateScore[i] = -1000;
                    }
                    else
                    {
                        StateScore[i] = 100;
                        StateScore[i] -= transform.position.y;
                        //calculate x distance
                        if (transform.position.x >= 0 && virus.transform.position.x <= 0 || transform.position.x <= 0 && virus.transform.position.x >= 0)
                        {
                            Xdistance = Mathf.Abs(transform.position.x) + Mathf.Abs(virus.transform.position.x);
                        }
                        else if (transform.position.x < 0 && virus.transform.position.x < 0)
                        {
                            Xdistance = Mathf.Abs(virus.transform.position.x) - Mathf.Abs(transform.position.x);
                        }
                        else
                        {
                            Xdistance = virus.transform.position.x - transform.position.x;
                        }
                        //continue to calculate the score
                        StateScore[i] += Mathf.Abs(Xdistance);
                        //if there is red next to the virus
                        for (int o = 0; o < 8; o++)
                        {
                            if (BN.collide[o] != "") { StateScore[i] -= 1; }

                        }
                    }
                    break;

                case 3:
                    transform.position = new Vector2(transform.position.x - 2, transform.position.y);
                    //calculate score
                    if (virus.transform.position.y < 0) { StateScore[i] = 1000; }
                    else if (transform.position.y > 10 || transform.position.x > 8 || transform.position.x < -8)
                    {
                        StateScore[i] = -1000;
                    }
                    else if (virus.transform.position == transform.position)
                    {
                        StateScore[i] = -1000;
                    }
                    else
                    {
                        StateScore[i] = 100;
                        StateScore[i] -= transform.position.y;
                        //calculate x distance
                        if (transform.position.x >= 0 && virus.transform.position.x <= 0 || transform.position.x <= 0 && virus.transform.position.x >= 0)
                        {
                            Xdistance = Mathf.Abs(transform.position.x) + Mathf.Abs(virus.transform.position.x);
                        }
                        else if (transform.position.x < 0 && virus.transform.position.x < 0)
                        {
                            Xdistance = Mathf.Abs(virus.transform.position.x) - Mathf.Abs(transform.position.x);
                        }
                        else
                        {
                            Xdistance = virus.transform.position.x - transform.position.x;
                        }
                        //continue to calculate the score
                        StateScore[i] += Mathf.Abs(Xdistance);
                        //if there is red next to the virus
                        for (int o = 0; o < 8; o++)
                        {
                            if (BN.collide[o] != "") { StateScore[i] -= 1; }

                        }
                    }
                    break;
                case 4:
                    transform.position = new Vector2(transform.position.x + 2, transform.position.y);
                    //calculate score
                    if (virus.transform.position.y < 0) { StateScore[i] = 1000; }
                    else if (transform.position.y > 10 || transform.position.x > 8 || transform.position.x < -8)
                    {
                        StateScore[i] = -1000;
                    }
                    else if (virus.transform.position == transform.position)
                    {
                        StateScore[i] = -1000;
                    }
                    else
                    {
                        StateScore[i] = 100;
                        StateScore[i] -= transform.position.y;
                        //calculate x distance
                        if (transform.position.x >= 0 && virus.transform.position.x <= 0 || transform.position.x <= 0 && virus.transform.position.x >= 0)
                        {
                            Xdistance = Mathf.Abs(transform.position.x) + Mathf.Abs(virus.transform.position.x);
                        }
                        else if (transform.position.x < 0 && virus.transform.position.x < 0)
                        {
                            Xdistance = Mathf.Abs(virus.transform.position.x) - Mathf.Abs(transform.position.x);
                        }
                        else
                        {
                            Xdistance = virus.transform.position.x - transform.position.x;
                        }
                        //continue to calculate the score
                        StateScore[i] += Mathf.Abs(Xdistance);
                        //if there is red next to the virus
                        for (int o = 0; o < 8; o++)
                        {
                            if (BN.collide[o] != "") { StateScore[i] -= 1; }

                        }
                    }
                    break;
                case 5:
                    transform.position = new Vector2(transform.position.x + 2, transform.position.y + 2);
                    //calculate score
                    if (virus.transform.position.y < 0) { StateScore[i] = 1000; }
                    else if (transform.position.y > 10 || transform.position.x > 8 || transform.position.x < -8)
                    {
                        StateScore[i] = -1000;
                    }
                    else if (virus.transform.position == transform.position)
                    {
                        StateScore[i] = -1000;
                    }
                    else
                    {
                        StateScore[i] = 100;
                        StateScore[i] -= transform.position.y;
                        //calculate x distance
                        if (transform.position.x >= 0 && virus.transform.position.x <= 0 || transform.position.x <= 0 && virus.transform.position.x >= 0)
                        {
                            Xdistance = Mathf.Abs(transform.position.x) + Mathf.Abs(virus.transform.position.x);
                        }
                        else if (transform.position.x < 0 && virus.transform.position.x < 0)
                        {
                            Xdistance = Mathf.Abs(virus.transform.position.x) - Mathf.Abs(transform.position.x);
                        }
                        else
                        {
                            Xdistance = virus.transform.position.x - transform.position.x;
                        }
                        //continue to calculate the score
                        StateScore[i] += Mathf.Abs(Xdistance);
                        //if there is red next to the virus
                        for (int o = 0; o < 8; o++)
                        {
                            if (BN.collide[o] != "") { StateScore[i] -= 1; }

                        }
                    }
                    break;
                case 6:
                    transform.position = new Vector2(transform.position.x - 2, transform.position.y + 2);
                    //calculate score
                    if (virus.transform.position.y < 0) { StateScore[i] = 1000; }
                    else if (transform.position.y > 10 || transform.position.x > 8 || transform.position.x < -8)
                    {
                        StateScore[i] = -1000;
                    }
                    else if (virus.transform.position == transform.position)
                    {
                        StateScore[i] = -1000;
                    }
                    else
                    {
                        StateScore[i] = 100;
                        StateScore[i] -= transform.position.y;
                        //calculate x distance
                        if (transform.position.x >= 0 && virus.transform.position.x <= 0 || transform.position.x <= 0 && virus.transform.position.x >= 0)
                        {
                            Xdistance = Mathf.Abs(transform.position.x) + Mathf.Abs(virus.transform.position.x);
                        }
                        else if (transform.position.x < 0 && virus.transform.position.x < 0)
                        {
                            Xdistance = Mathf.Abs(virus.transform.position.x) - Mathf.Abs(transform.position.x);
                        }
                        else
                        {
                            Xdistance = virus.transform.position.x - transform.position.x;
                        }
                        //continue to calculate the score
                        StateScore[i] += Mathf.Abs(Xdistance);
                        //if there is red next to the virus
                        for (int o = 0; o < 8; o++)
                        {
                            if (BN.collide[o] != "") { StateScore[i] -= 1; }

                        }
                    }
                    break;
                case 7:
                    transform.position = new Vector2(transform.position.x + 2, transform.position.y - 2);
                    //calculate score
                    if (virus.transform.position.y < 0) { StateScore[i] = 1000; }
                    else if (transform.position.y > 10 || transform.position.x > 8 || transform.position.x < -8)
                    {
                        StateScore[i] = -1000;
                    }
                    else if (virus.transform.position == transform.position)
                    {
                        StateScore[i] = -1000;
                    }
                    else
                    {
                        StateScore[i] = 100;
                        StateScore[i] -= transform.position.y;
                        //calculate x distance
                        if (transform.position.x >= 0 && virus.transform.position.x <= 0 || transform.position.x <= 0 && virus.transform.position.x >= 0)
                        {
                            Xdistance = Mathf.Abs(transform.position.x) + Mathf.Abs(virus.transform.position.x);
                        }
                        else if (transform.position.x < 0 && virus.transform.position.x < 0)
                        {
                            Xdistance = Mathf.Abs(virus.transform.position.x) - Mathf.Abs(transform.position.x);
                        }
                        else
                        {
                            Xdistance = virus.transform.position.x - transform.position.x;
                        }
                        //continue to calculate the score
                        StateScore[i] += Mathf.Abs(Xdistance);
                        //if there is red next to the virus
                        for (int o = 0; o < 8; o++)
                        {
                            if (BN.collide[o] != "") { StateScore[i] -= 1; }

                        }
                    }
                    break;
                case 1:
                    transform.position = new Vector2(transform.position.x - 2, transform.position.y - 2);
                    //calculate score
                    if (virus.transform.position.y < 0) { StateScore[i] = 1000; }
                    else if (transform.position.y > 10 || transform.position.x > 8 || transform.position.x < -8)
                    {
                        StateScore[i] = -1000;
                    }
                    else if (virus.transform.position == transform.position)
                    {
                        StateScore[i] = -1000;
                    }
                    else
                    {
                        StateScore[i] = 100;
                        StateScore[i] -= transform.position.y;
                        //calculate x distance
                        if (transform.position.x >= 0 && virus.transform.position.x <= 0 || transform.position.x <= 0 && virus.transform.position.x >= 0)
                        {
                            Xdistance = Mathf.Abs(transform.position.x) + Mathf.Abs(virus.transform.position.x);
                        }
                        else if (transform.position.x < 0 && virus.transform.position.x < 0)
                        {
                            Xdistance = Mathf.Abs(virus.transform.position.x) - Mathf.Abs(transform.position.x);
                        }
                        else
                        {
                            Xdistance = virus.transform.position.x - transform.position.x;
                        }
                        //continue to calculate the score
                        StateScore[i] += Mathf.Abs(Xdistance);
                        //if there is red next to the virus
                        for (int o = 0; o < 8; o++)
                        {
                            if (BN.collide[o] != "") { StateScore[i] -= 1; }

                        }

                    }
                    break;
                default:
                    break;
                    // from 8 to 15 are moves that calculate red so instea of moving the player dummy move a red block

            


            }




        }
        //choose the best one and save the score
        for (int i = 7; i >= 0; i--)
        {
            if (max < StateScore[i] /*+ StateScore[i - 8]*/)
            {
                max = StateScore[i];
            }
        }
        BN.StateScore[d] = max;
        print(BN.StateScore[d]);
        max = 0;
        //at the end let the dummy see the next move

        CanContinue = true;
    }
}
