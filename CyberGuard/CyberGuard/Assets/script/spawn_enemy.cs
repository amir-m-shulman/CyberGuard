using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawn_enemy : MonoBehaviour
{
    GameObject virus;
    [SerializeField] GameObject SBV;
    [SerializeField] GameObject BlueVirusOne;
    [SerializeField] PlayerMovement PM;
    public static int enters;
    public static string SpawnEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "fight")
        {
            if (enters == 0)
            {
                PlayerMovement.enemy = "stupid blue virus";
            }

            if (PlayerMovement.enemy == "stupid blue virus")
            {
                virus = Instantiate(SBV);
                if (enters == 0) { virus.transform.position = new Vector2(-6, 10); }
                else { virus.transform.position = new Vector2(-8, 10); }
            }
        }
        else if(scene.name == "fight 1")
        {
            if(SpawnEnemy == "BasicBlue")
            {
                virus = Instantiate(BlueVirusOne);
                
            }
        }
        
        PM.CanMove = false;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
