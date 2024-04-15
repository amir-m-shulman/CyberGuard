using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBN : MonoBehaviour
{
    [SerializeField] string massege;
    public string[] collide;
    public float[] StateScore;
    DummyP_BN DPBN;
    [SerializeField] GameObject virus;
    public bool CanCalculate = false;
    



    // Start is called before the first frame update
    void Start()
    {
        //if (spawn_enemy.enters == 0) { Destroy(this); }
        DPBN = FindObjectOfType<DummyP_BN>();



    }
    

    public void Movedummy()
    {
        CanCalculate = false;
       for(int i = 0; i < 16; i++)
        {
            transform.position = virus.transform.position;
            switch (i)
            {
                case 0:
                case 8:
                    transform.position = new Vector2(transform.position.x, transform.position.y - 2);
                    if (!DPBN.CanContinue) { return; }
                    DPBN.CalculateState(0);
                    break;
                case 2:
                case 10:
                    transform.position = new Vector2(transform.position.x, transform.position.y + 2);
                    if (!DPBN.CanContinue) { return; }
                    DPBN.CalculateState(1);


                    break;
                case 3:
                case 11:
                    transform.position = new Vector2(transform.position.x - 2, transform.position.y);
                    if (!DPBN.CanContinue) { return; }
                    DPBN.CalculateState(2);


                    break;
                case 4:
                case 12:
                    transform.position = new Vector2(transform.position.x + 2, transform.position.y);
                    if (!DPBN.CanContinue) { return; }

                    break;
                case 5:
                case 13:
                    transform.position = new Vector2(transform.position.x + 2, transform.position.y + 2);
                    if (!DPBN.CanContinue) { return; }
                    DPBN.CalculateState(4);

                    break;
                case 6:
                case 14:
                    transform.position = new Vector2(transform.position.x - 2, transform.position.y + 2);
                    if (!DPBN.CanContinue) { return; }
                    DPBN.CalculateState(5);


                    break;
                case 7:
                case 15:
                    transform.position = new Vector2(transform.position.x + 2, transform.position.y - 2);
                    if (!DPBN.CanContinue) { return; }
                    DPBN.CalculateState(6);

                    break;
                case 1:
                case 9:
                    transform.position = new Vector2(transform.position.x - 2, transform.position.y - 2);
                    if (!DPBN.CanContinue) { return; }
                    DPBN.CalculateState(7);
                    break;
                
            }
        }
        //enable calculation
        CanCalculate = true;
        

        
    }
}
