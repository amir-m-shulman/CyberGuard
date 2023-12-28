using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_F_P : MonoBehaviour
{
    SpriteRenderer SR;
    
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("computa"))
        {
            Cursor.visible = false;
            SR.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("computa"))
        {
            Cursor.visible = true;
            SR.enabled = false;
        }
    }
}
