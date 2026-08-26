using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;

    void FixedUpdate()
    {
        agent.SetDestination(target.transform.position);
    }
}