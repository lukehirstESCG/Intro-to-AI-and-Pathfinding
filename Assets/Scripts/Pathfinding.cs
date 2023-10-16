using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public Transform[] points;
    private NavMeshAgent agent;
    private int dest;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();    
    }

    private void FixedUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
    }

    public void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        agent.destination = points[dest].position;
        dest = (dest + 1) % points.Length;
    }
}
