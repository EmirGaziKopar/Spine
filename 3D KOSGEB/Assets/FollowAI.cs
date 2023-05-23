using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    public GameObject AI;
    public float speed = 1f; // Takip hýzý
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    
        

    void Update()
    {
        if (AI != null)
        {
            Vector3 targetPosition = new Vector3(AI.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }


  }
}

