using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRedN : MonoBehaviour
{
    [SerializeField] string massege;
    PlayerMovement pm;
    LayerMask l;
    RaycastHit2D ray;
    normal n;



    // Start is called before the first frame update
    void Start()
    {
        //if (spawn_enemy.enters == 0) { Destroy(this); }
        pm = FindObjectOfType<PlayerMovement>();
        n = GetComponentInParent<normal>();
        l = LayerMask.GetMask("red");


    }
    private void FixedUpdate()
    {
        // rays

        if (!pm.GoNpc)
        {
            switch (massege)
            {
                case "down":
                    ray = Physics2D.Raycast(transform.position, -Vector2.up, 3, l);
                    Debug.DrawRay(transform.position, -Vector2.up * 3, Color.red);
                    break;
                case "up":
                    ray = Physics2D.Raycast(transform.position, Vector2.up, 3, l);
                    Debug.DrawRay(transform.position, Vector2.up * 3, Color.red);
                    break;
                case "left":
                    ray = Physics2D.Raycast(transform.position, Vector2.left, 3, l);
                    Debug.DrawRay(transform.position, Vector2.left * 3, Color.red);
                    break;
                case "right":
                    ray = Physics2D.Raycast(transform.position, Vector2.right, 3, l);
                    Debug.DrawRay(transform.position, Vector2.right * 3, Color.red);
                    break;
                case "up right":
                    ray = Physics2D.Raycast(transform.position, new Vector2(1, 1), 3, l);
                    Debug.DrawRay(transform.position, new Vector2(1, 1) * 3, Color.red);
                    break;
                case "up left":
                    ray = Physics2D.Raycast(transform.position, new Vector2(-1, 1), 3, l);
                    Debug.DrawRay(transform.position, new Vector2(-1, 1) * 3, Color.red);
                    break;
                case "down right":
                    ray = Physics2D.Raycast(transform.position, new Vector2(1, -1), 3, l);
                    Debug.DrawRay(transform.position, new Vector2(1, -1) * 3, Color.red);
                    break;
                case "down left":
                    ray = Physics2D.Raycast(transform.position, new Vector2(-1, -1), 3, l);
                    Debug.DrawRay(transform.position, new Vector2(-1, -1) * 3, Color.red);
                    break;




            }

        }



        if (ray.collider != null)
        {
            if (ray.collider.CompareTag("red") || (ray.collider.CompareTag("Player")))
            {
                switch (massege)
                {
                    case "down":
                        n.masseges[0] = "down";
                        goto case "up";
                    case "up":
                        n.masseges[1] = "up";
                        goto case "left";
                    case "left":
                        n.masseges[2] = "left";
                        goto case "right";
                    case "right":
                        n.masseges[3] = "right";
                        goto case "up right";
                    case "up right":
                        n.masseges[4] = "up right";
                        goto case "up left";
                    case "up left":
                        n.masseges[5] = "up left";
                        goto case "down right";
                    case "down right":
                        n.masseges[6] = "down right";
                        goto case "down left";
                    case "down left":
                        n.masseges[7] = "down left";
                        break;




                }

            }

        }
    }



}
