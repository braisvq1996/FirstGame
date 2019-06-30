using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private PlayerController player;

    private enemyController enemy;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag== "ground")
        {
            player.grounded = true;
        }else 
        if (col.gameObject.tag == "platfrom")
        {
            player.transform.parent = col.transform;
            
            player.grounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            player.grounded = false;
        }
        else
        if (col.gameObject.tag == "platfrom")
        {
            player.transform.parent = null;
            player.grounded = false;
        }
    }
}
