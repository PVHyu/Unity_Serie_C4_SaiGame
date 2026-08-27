using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyMoving : SaiMonoBehaviour
{
    public GameObject target;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected int pathIndex = 0;
    [SerializeField] protected string pathName;
    [SerializeField] protected Path enemyPath;
    [SerializeField] protected Point currentPoint;
    [SerializeField] protected float pointDistance = Mathf.Infinity;
    [SerializeField] protected float stopDistance = 1f;
    [SerializeField] protected bool isFinish = false;

    protected override void Start()
    {
        this.LoadEnemyPath();
    }

    void FixedUpdate()
    {
        this.Moving();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
        this.LoadTarget();
    }

    protected virtual void LoadCtrl()
    {
        if(this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": EnemyCtrl", gameObject);
    }

    protected virtual void LoadTarget()
    {
        if(this.target != null) return;
        this.target = GameObject.Find("TargetMoving");
        Debug.Log(transform.name + ": LoadTarget", gameObject);
    }

    protected virtual void Moving()
    {
        this.FindNextPoint();
        if(this.currentPoint == null || this.isFinish == true)
        {
            this.enemyCtrl.Agent.isStopped = true;
            return;
        }
        this.enemyCtrl.Agent.SetDestination(this.currentPoint.transform.position);
    }

    protected virtual void FindNextPoint()
    {
        if(this.currentPoint == null) this.currentPoint = this.enemyPath.GetPoint(0);

        this.pointDistance = Vector3.Distance(transform.position, this.currentPoint.transform.position);
        if(this.pointDistance < this.stopDistance)
        {
            this.currentPoint = this.currentPoint.NextPoint;
            if (this.currentPoint == null) this.isFinish = true;
        }
    }

    protected virtual void LoadEnemyPath()
    {
        if(this.enemyPath != null) return;
        this.enemyPath = PathsManager.Instance.GetPath(this.pathName);
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
}