using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.FilePathAttribute;
using static UnityEngine.GraphicsBuffer;

public class Hide : MonoBehaviour
{
    GameObject[] hidingSpots;
    public GameObject target;
    NavMeshAgent agent;
    public int hideFrequency = 30;
    int timer = 0;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        hidingSpots = GameObject.FindGameObjectsWithTag("Hide");
    }



    public Vector3 hide()
    {
        float dist = Mathf.Infinity;
        Vector3 chosenSpot = Vector3.zero;
        Vector3 chosenDir = Vector3.zero;
        GameObject chosenGO = hidingSpots[0];

        for (int i = 0; i < hidingSpots.Length; i++)
        {
            Vector3 hideDir = hidingSpots[i].transform.position - target.transform.position;
            Vector3 hidePos = hidingSpots[i].transform.position + hideDir.normalized * 100;

            if (Vector3.Distance(transform.position, hidePos) < dist)
            {
                chosenSpot = hidePos;
                chosenDir = hideDir;
                chosenGO = hidingSpots[i];
                dist = Vector3.Distance(this.transform.position, hidePos);
            }
        }

        Collider hideCol = chosenGO.GetComponent<Collider>();
        Ray backRay = new Ray(chosenSpot, -chosenDir.normalized);
        RaycastHit info;
        float distance = 250.0f;
        hideCol.Raycast(backRay, out info, distance);


        return info.point + chosenDir.normalized;
    }

    public void Update()
    {
        if(timer == 0)
        {
            agent.SetDestination(hide());
            timer = hideFrequency;
        }
        timer--;
    }
}
