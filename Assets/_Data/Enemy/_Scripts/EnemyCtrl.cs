using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;

   protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
        this.LoadModel();
    }

    protected virtual void LoadNavMeshAgent()
    {
        if(this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        this.agent.speed = 20f;
        this.agent.angularSpeed = 120f;
        this.agent.acceleration = 8f;
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }

    protected virtual void LoadModel()
    {
        if(this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }
}