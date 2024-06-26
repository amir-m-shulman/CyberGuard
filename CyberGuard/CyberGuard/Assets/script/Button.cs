using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class Button : MonoBehaviour
{
    [SerializeField] Light2D L;
    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement PM;
    bool go;
    public bool NoRed;
    BoxCollider2D boxy;
    // Start is called before the first frame update
    private void Start()
    {
        boxy = player.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(go )
        {
            boxy.enabled = false;

            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, 15 * Time.deltaTime);
            if(player.transform.position == transform.position)
            {
                go = false;
                boxy.enabled = true;

            }
        }
    }
    private void OnMouseEnter()
    {
        L.intensity = 1.5f;

    }
    private void OnMouseOver()
    {
        if ( Input.GetKey("space") &&  PM.control == "player" && PM.PlayerTurn && Vector2.Distance(player.transform.position,transform.position) < 3 && Vector2.Distance(player.transform.position, transform.position) > 1)
        {
            PM.PlayerTurn = false;
            Invoke("gonpc", 0.5f);
            print("move!");
            go = true;
        }
        else if(Input.GetKey("space") && PM.control == "red" && !NoRed && PM.PlayerTurn)
        {
            PM.PlayerTurn = false;
            transform.gameObject.tag = "red";
            gameObject.layer = 6;
            Invoke("gonpc", 0.5f);
            // make game square red
            L.color = Color.red;
            //change turns
            
        }
    }

    private void OnMouseExit()
    {
        L.intensity = 0.4f;
    }
    private void gonpc()
    {
        PM.GoNpc = true;
    }
}
