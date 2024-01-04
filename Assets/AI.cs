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

    public Animator animator;
    Rigidbody rb;
    NavMeshAgent agent;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        animator.Play("Idle");
        
    }
    private void Update()
    {
        //transform.LookAt(target);
        //rb.velocity = transform.forward * speed;
        if (target == null) return;
        agent.speed = speed;
        var distance = Vector3.Distance(transform.position, target.position);
        if (agent.velocity != Vector3.zero)
        {
            animator.Play("Run");
        }
        else
        {
            animator.Play("Idle");
        }

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
                agent.destination += Random.insideUnitSphere * wanderDistance;
            }
        }
    }
}
