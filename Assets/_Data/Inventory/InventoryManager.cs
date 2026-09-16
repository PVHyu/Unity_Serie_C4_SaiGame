using com.cyborgAssets.inspectorButtonPro;
using System;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : SaiSingleton<InventoryManager>
{
    [SerializeField] protected List<InventoryCtrl> inventories;
    [SerializeField] protected List<ItemProfileSO> itemProfiles;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventories();
        // this.LoadItemProfiles();
    }

    protected virtual void LoadInventories()
    {
        if(this.inventories.Count > 0) return;
        foreach(Transform child in transform)
        {
            InventoryCtrl inventoryCtrl = child.GetComponent<InventoryCtrl>();
            if(inventoryCtrl == null) continue;
            this.inventories.Add(inventoryCtrl);
        }
    }    

    public virtual InventoryCtrl GetByCodeName(InvCodeName inventoryName)
    {
        foreach(InventoryCtrl inventory in this.inventories)
        {
            if(inventory.GetName() == inventoryName) return inventory;
        }
        return null;
    }

    public virtual ItemProfileSO GetProfileByCode(ItemCode itemCodeName)
    {
        foreach(ItemProfileSO itemProfile in this.itemProfiles)
        {
            if(itemProfile.itemCode == itemCodeName) return itemProfile;
        }
        Debug.Log(itemCodeName.ToString() + "return Null");
        return null;
    }

    public virtual InventoryCtrl Monies()
    {
        return this.GetByCodeName(InvCodeName.Currency);
    }

    public virtual InventoryCtrl Items()
    {
        return this.GetByCodeName(InvCodeName.Items);
    }

    protected virtual void LoadItemProfiles()
    {
        if(this.itemProfiles.Count > 0) return;
        ItemProfileSO[] itemProfileSOs = Resources.LoadAll<ItemProfileSO>("/");
        this.itemProfiles = new List<ItemProfileSO>(itemProfileSOs);
        Debug.Log(transform.name + ": LoadItemProfiles", gameObject);
    }

     public virtual void AddItem(ItemInventory itemInventory)
    {
        InvCodeName invCodeName = itemInventory.ItemProfile.invCodeName;
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByCodeName(invCodeName);
        inventoryCtrl.AddItem(itemInventory);
    }

    public virtual void AddItem(ItemCode itemCode, int itemCount)
    {
        ItemProfileSO itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
        if(itemProfile == null) Debug.Log("itemProfile is null");
        ItemInventory item = new(itemProfile, itemCount);
        if(item == null) Debug.Log("item is null");
        this.AddItem(item);
    }
}