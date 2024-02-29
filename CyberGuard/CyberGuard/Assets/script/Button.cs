using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class Button : MonoBehaviour
{
    [SerializeField] Light2D L;
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
    private void OnMouseExit()
    {
        L.intensity = 0.4f;
    }
}
