
using UnityEngine;

public class make_p_move : MonoBehaviour
{
    [SerializeField] PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        pm.CanMove = true;
    }

    
}
