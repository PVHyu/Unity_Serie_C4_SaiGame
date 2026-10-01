using UnityEngine;

public class BtnSettingToogle : ButttonAbstract
{
    protected virtual void LateUpdate()
    {
        this.HotkeyToogleSetting();
    }

    protected override void OnClick()
    {
        SettingUI.Instance.Toggle();
    }

    protected virtual void HotkeyToogleSetting()
    {
        if (InputHotkeys.Instance.isToogleSetting) SettingUI.Instance.Toggle();
    }
}