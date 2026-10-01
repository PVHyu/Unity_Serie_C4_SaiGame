using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCloseSetting : ButttonAbstract
{
    public virtual void CloseSettingUI()
    {
        SettingUI.Instance.Hide();
    }

    protected override void OnClick()
    {
        this.CloseSettingUI();
    }
}