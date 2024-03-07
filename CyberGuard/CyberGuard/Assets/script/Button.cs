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
    // Start is called before the first frame update
    
    private void Update()
    {
        if(go)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, 15 * Time.deltaTime);
            if(player.transform.position == transform.position)
            {
                go = false;
            }
        }
    }
    private void OnMouseEnter()
    {
        L.intensity = 1.5f;

    }
    private void OnMouseOver()
    {
        if ( Input.GetKey("space") &&  PM.control == "player" && PM.PlayerTurn && Vector2.Distance(player.transform.position,transform.position) < 3 * PM.Mish)
        {
            //player.transform.position = transform.position;
            PM.PlayerTurn = false;
            Invoke("gonpc", 0.5f);
            print("move!");
            go = true;
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
