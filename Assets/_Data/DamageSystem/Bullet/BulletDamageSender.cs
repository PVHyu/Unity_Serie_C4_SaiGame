using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if(this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
    }

    protected virtual void LoadSphereCollider()
    {
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
    }

    protected override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.bulletCtrl.Bullet.Despawn.DoDespawn();
    }
}