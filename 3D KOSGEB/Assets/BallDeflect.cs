using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeflect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {

            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        }
    }
    
}
