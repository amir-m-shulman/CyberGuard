using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stupid : MonoBehaviour
{
    PlayerMovement PM;
    Vector3 p;
    private bool once = false;
    private Animator a;
    private bool nomove = false;
    [SerializeField] GameObject lose_screen;
    next_scene ns;
    public string WhereHit;
    // Start is called before the first frame update
    void Start()
    {
        GameObject p = GameObject.Find("Player");
        PM = p.GetComponent<PlayerMovement>();
        a = GetComponent<Animator>();
        ns = p.GetComponent<next_scene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PM.GoNpc)
        {
            if (once) 
            {
                if(spawn_enemy.enters == 0)
                {
                    p = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
                }
                else if(WhereHit != "red")
                {
                    p = new Vector3(transform.position.x, transform.position.y - 4, transform.position.z);
                }
                else { p = new Vector3(transform.position.x + 2, transform.position.y - 2, transform.position.z); WhereHit = "none"; }
                once = false;
            }
            

            if(transform.position != p && !nomove)
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
        if(collision.gameObject.CompareTag("Finish"))
        {
            lose_screen.SetActive(true);
            print("you lost!");
        }
    }
    private void moveplayer()
    {
        PM.PlayerTurn = true;
    }
    private void die()
    {
        nomove = true;
        a.SetTrigger("die");
        spawn_enemy.enters += 1;
        print(spawn_enemy.enters);
        Invoke("dt", 1);
    }
    private void dt()
    {
        ns.Next_level();
        Destroy(this);
    }
}
