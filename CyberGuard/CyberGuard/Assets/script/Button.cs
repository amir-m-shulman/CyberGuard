using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class Button : MonoBehaviour
{
    [SerializeField] Light2D L;
    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement PM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        L.intensity = 1.5f;

    }
    private void OnMouseOver()
    {
        if (PM.control == "player" && Input.GetKey("space") && PM.PlayerTurn)
        {
            player.transform.position = transform.position;
            print("move!");
        }
    }

    private void OnMouseExit()
    {
        L.intensity = 0.4f;
    }
}
