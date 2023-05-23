using UnityEngine;
using UnityEngine.AI;

public class HorizontalRandomMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 destination;

    public float minX = -10f; // Minimum x (yatay) pozisyon deðeri
    public float maxX = 10f;  // Maximum x (yatay) pozisyon deðeri

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetRandomDestination();
        }
    }

    private void SetRandomDestination()
    {
        float randomX = Random.Range(minX, maxX);
        destination = new Vector3(randomX, transform.position.y, transform.position.z);
        agent.SetDestination(destination);
    }
}
