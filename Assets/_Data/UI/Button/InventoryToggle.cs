using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : ButttonAbstract
{
    protected override void OnClick()
    {
        InventoryUI.Instance.Toggle();
    }
}