using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

   protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
        this.LoadModel();
        this.LoadAnimator();
    }

    protected virtual void LoadNavMeshAgent()
    {
        if(this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        this.agent.speed = 20f;
        this.agent.angularSpeed = 120f;
        this.agent.acceleration = 50f;
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }

    protected virtual void LoadModel()
    {
        if(this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = model.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
}