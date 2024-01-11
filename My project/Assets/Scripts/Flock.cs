using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flock : MonoBehaviour
{
    public float speed;
    public FlockManager myManager;
    private float et, lt;
    public Vector3 direction;
    public float error;

    // Start is called before the first frame update
    void Start()
    {
        direction = transform.forward;
        et = 0f;
        lt = Random.Range(0.3f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        et += Time.deltaTime;
        if (et > lt)
        {
            Flocking();
            et = 0f;
            lt = Random.Range(0.3f, 0.5f);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation,
                                      Quaternion.LookRotation(direction),
                                      myManager.rotationSpeed * Time.deltaTime);
        transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
    }

    void Flocking()
    {
        Vector3 cohesion = Vector3.zero;
        Vector3 align = Vector3.zero;
        Vector3 separation = Vector3.zero;
        int num = 0;

        foreach (GameObject go in myManager.allBees)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    cohesion += go.transform.position;
                    align += go.GetComponent<Flock>().direction;
                    separation -= (transform.position - go.transform.position) /
                        (distance * distance);
                    num++;
                }
            }

        }
        if (num > 0)
        {
            cohesion = (cohesion / num - transform.position).normalized * speed;
            align /= num;
            speed = Mathf.Clamp(align.magnitude, myManager.minSpeed, myManager.maxSpeed);
        }

        Vector3 rand;
        rand.x = Random.Range(-error, error);
        rand.y = Random.Range(-error, error);
        rand.z = Random.Range(-error, error);

        Vector3 lead = Vector3.zero;
        if (myManager.leading)
            lead = (myManager.leader.transform.position - transform.position);

        direction = (cohesion + align + separation + rand + lead).normalized * speed;
    }
}
