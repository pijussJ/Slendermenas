using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float viewDistance = 20;
    public float wanderDistance = 10;

    Rigidbody rb;
    NavMeshAgent agent;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }
    private void Update()
    {
        //transform.LookAt(target);
        //rb.velocity = transform.forward * speed;

        var distance = Vector3.Distance(transform.position, target.position);
        if (distance < viewDistance)
        {
            // CHASE
            agent.destination = target.position;
        }
        else
        {
            // SEEK
            if (agent.velocity == Vector3.zero)
            {
                agent.destination = Random.insideUnitSphere * wanderDistance;
            }
        }
    }
}
