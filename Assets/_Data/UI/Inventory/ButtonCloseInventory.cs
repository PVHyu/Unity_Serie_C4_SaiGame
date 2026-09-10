using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCloseInventory : ButttonAbstract
{
    public virtual void CloseInventoryUI()
    {
        InventoryUI.Instance.Hide();
    }

    protected override void OnClick()
    {
        this.CloseInventoryUI();
    }
}