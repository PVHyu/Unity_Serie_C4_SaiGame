using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ItemDropCtrl : PoolObject
{
    [SerializeField] protected Rigidbody _rigid;
    public Rigidbody Rigidbody => _rigid;

    protected InvCodeName inventoryCodeName = InvCodeName.Items;
    public InvCodeName InvCodeName => inventoryCodeName;
    protected ItemCode itemCode;
    public ItemCode ItemCode => itemCode;
    protected int itemCount = 1;
    protected int ItemCount => itemCount;


    public override string GetName()
    {
        return "ItemDrop";
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();  
        this.LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if(this._rigid != null) return;
        this._rigid = GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    public virtual void SetValue(ItemCode itemCode, int itemCount)
    {
        this.itemCode = itemCode;
        this.itemCount = itemCount;
    }

    public virtual void SetValue(ItemCode itemCode, int itemCount, InvCodeName invCodeName)
    {
        this.itemCode = itemCode;
        this.itemCount = itemCount;
        this.inventoryCodeName = invCodeName;
    }
}