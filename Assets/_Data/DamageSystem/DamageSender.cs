using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public abstract class DamageSender : SaiMonoBehaviour
{
    [SerializeField] protected Rigidbody rigidbody;
    [SerializeField] protected int damage = 1;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
    }

    public virtual void OnTriggerEnter(Collider collider)
    {
        DamageReceiver damageReceiver = collider.GetComponent<DamageReceiver>();
        if(damageReceiver == null) return;
        this.Send(damageReceiver);
        Debug.Log("OnTriggerEnter: " + collider.name);
    }

    protected virtual void Send(DamageReceiver damageReceiver)
    {
        if(damageReceiver == null) Debug.Log("DamageReceiver is null");
        damageReceiver.Deduct(this.damage);
    }

    protected virtual void LoadRigidbody()
    {
        if(this.rigidbody != null) return;
        this.rigidbody = GetComponent<Rigidbody>();
        this.rigidbody.useGravity = false;
    }
}