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
        this.AddTestItems(10);
        this.AddTestGold(100);
        Invoke(nameof(this.AddTestItemDelay), 7f);
    }

    protected virtual void AddTestItemDelay()
    {
        this.AddTestItems(5);
    }

    protected virtual void AddTestItems(int count)
    {
        InventoryCtrl items = this.GetByName(InvCodeName.Items);
        for(int i = 0; i < count; i++)
        {
            ItemInventory wand = new ItemInventory
            {
                ItemProfile = this.GetProfileByCode(ItemCode.Wand), 
                itemName = this.GetProfileByCode(ItemCode.Wand).itemName,
                itemCount = 1,
            };
            items.AddItem(wand);
        }
    }

    protected virtual void AddTestGold(int count)
    {
        InventoryCtrl monies = this.GetByName(InvCodeName.Monies);

        ItemInventory gold = new ItemInventory
            {
                ItemProfile = this.GetProfileByCode(ItemCode.Gold),
                itemName = this.GetProfileByCode(ItemCode.Gold).itemName,
                itemCount = count,
            };
        monies.AddItem(gold);
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