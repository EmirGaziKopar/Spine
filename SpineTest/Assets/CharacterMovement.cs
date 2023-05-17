using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CharacterAnimController.leftMove)
        {
            rigidbody2D.velocity = new Vector2(-speed*1, 0);
        }
        if (CharacterAnimController.rightMove)
        {
            rigidbody2D.velocity = new Vector2(speed * 1, 0);
        }
    }
}
