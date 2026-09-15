using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropDespawn : Despawn<ItemDropCtrl>
{
    public override void DoDespawn()
    {
        ItemDropCtrl itemDropCtrl = (ItemDropCtrl) this.parent;
        ItemInventory item = new()
        {
            ItemProfile = InventoryManager.Instance.GetProfileByCode(ItemCode.Gold), 
            itemCount = 1
        };
        InventoryManager.Instance.GetByCodeName(itemDropCtrl.InvCodeName)?.AddItem(item);
        base.DoDespawn();
    }
}