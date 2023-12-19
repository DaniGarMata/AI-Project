using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class patrol : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject[] waypoints;
    int patrolWP = 0;

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f) Patrol();
    }

    void Seek(GameObject go)
    {
        agent.destination = go.transform.position;
    }

    void Patrol()
    {
        patrolWP = (patrolWP + 1) % waypoints.Length;

        Seek(waypoints[patrolWP]);
    }
}


