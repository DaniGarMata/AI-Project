using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

public class Wander : MonoBehaviour
{
    Vector3 wanderTarget = Vector3.zero;
    public NavMeshAgent agent;
    public Collider floor;

    public int wanderFrequency = 10;
    int timer = 0;

    public float radius;
    public float offset;
    public float jitter;


    public void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }
    public void wander()
    {
        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * jitter,
                                        0,
                                        Random.Range(-1.0f, 1.0f) * jitter);
        wanderTarget.Normalize();
        wanderTarget *= radius;

        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, offset);
        Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(targetLocal);

        if (!floor.bounds.Contains(targetWorld))
        {
            targetWorld = -transform.position * 0.1f;

        };

        Seek(targetWorld);
    }
    public void Update()
    {
        if(timer == 0)
        {
            wander();
            timer = wanderFrequency;
        }

        timer--;
    }
}
