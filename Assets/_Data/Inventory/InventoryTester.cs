using com.cyborgAssets.inspectorButtonPro;
using System;
using System.Collections.Generic;
using UnityEngine;


public class InventoryTester : SaiMonoBehaviour
{
    [ProButton]
    public virtual void AddTestItems(int count)
    {
        InventoryCtrl items = InventoryManager.Instance.GetByName(InvCodeName.Items);
        for(int i = 0; i < count; i++)
        {
            ItemInventory wand = new ItemInventory
            {
                ItemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Wand), 
                itemName = InventoryManager.Instance.GetProfileByCode(ItemCode.Wand).itemName,
                itemCount = 1,
            };
            items.AddItem(wand);
        }
    }

    [ProButton]
    public virtual void RemoveTestItems(int count)
    {
        InventoryCtrl items = InventoryManager.Instance.GetByName(InvCodeName.Items);
        for(int i = 0; i < count; i++)
        {
            ItemInventory wand = new ItemInventory
            {
                ItemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Wand), 
                itemName = InventoryManager.Instance.GetProfileByCode(ItemCode.Wand).itemName,
                itemCount = 1,
            };

            items.RemoveItem(wand);
        }
    }

    [ProButton]
    public virtual void AddTestGold(int count)
    {
        InventoryCtrl monies = InventoryManager.Instance.GetByName(InvCodeName.Monies);

        ItemInventory gold = new ItemInventory
            {
                ItemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold),
                itemName = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold).itemName,
                itemCount = count,
            };
        monies.AddItem(gold);
    }

    [ProButton]
    public virtual void RemoveTestGold(int count)
    {
        InventoryCtrl monies = InventoryManager.Instance.GetByName(InvCodeName.Monies);

        ItemInventory gold = new ItemInventory
            {
                ItemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold),
                itemName = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold).itemName,
                itemCount = count,
            };
        monies.RemoveItem(gold);
    }
}