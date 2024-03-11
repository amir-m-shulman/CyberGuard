using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class red_button : MonoBehaviour
{
    [SerializeField] Light2D L;
    [SerializeField] PlayerMovement pm;
    private bool MO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !MO && pm.PlayerTurn)
        {
            L.intensity = 0.4f;
            

        }
        
    }
    private void OnMouseEnter()
    {
        L.intensity = 1.5f;
        MO = true;

    }
    
    private void OnMouseExit()
    {
        MO = false;
    
    }
    
    public void CR()
    {
        pm.control = "red";
        print("now control is red!");
    }
   
}
