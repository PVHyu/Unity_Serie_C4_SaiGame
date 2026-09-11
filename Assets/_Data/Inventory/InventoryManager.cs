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

    protected override void Start()
    {
        base.Start();
        this.AddTestItems();
    }

    protected virtual void AddTestItems()
    {
        InventoryCtrl inventoryCtrl = this.GetByName(InvCodeName.Monies);

        ItemInventory gold = new();
        gold.ItemProfile = this.GetProfileByCode(ItemCode.Gold);
        gold.itemName = gold.ItemProfile.itemName;
        gold.itemCount = 4;
        inventoryCtrl.AddItem(gold);

        InventoryCtrl items = this.GetByName(InvCodeName.Items);
        for(int i = 0; i < 20; i++)
        {
            ItemInventory wand = new();
            wand.ItemProfile = this.GetProfileByCode(ItemCode.Wand);
            wand.itemName = wand.ItemProfile.itemName;
            wand.itemCount = 1;
            items.AddItem(wand);
        }
        
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

    public virtual InventoryCtrl GetByName(InvCodeName inventoryName)
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
        return null;
    }

    public virtual InventoryCtrl Monies()
    {
        return this.GetByName(InvCodeName.Monies);
    }

    public virtual InventoryCtrl Items()
    {
        return this.GetByName(InvCodeName.Items);
    }
}