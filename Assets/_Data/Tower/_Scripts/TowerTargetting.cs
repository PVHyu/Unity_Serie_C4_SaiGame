using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]

public class TowerTargetting : SaiMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigid;
    [SerializeField] protected EnemyCtrl nearest;
    [SerializeField] protected List<EnemyCtrl> enemies = new();

    protected void FixedUpdate()
    {
        //this.FindNearest();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadSphereCollider()
    {
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 5f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if(this.rigid != null) return;
        this.rigid = GetComponent<Rigidbody>();
        this.rigid.useGravity = false;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
}