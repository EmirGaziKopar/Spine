using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySide : MonoBehaviour
{
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {

            Debug.Log("buraya girdi1");
            HorizontalRandomMoment.ballOnSide = true;

        }
        else
        {
            HorizontalRandomMoment.ballOnSide = false;
            Debug.Log("buraya girdi2");
        }
    }

}
