using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class TextPlayerLavelCount : TextAbstract
{

    protected virtual void FixedUpdate()
    {
        this.LoadCount();
    }

    protected virtual void LoadCount()
    {
        this.textPro.text = PlayerCtrl.Instance.Level.CurrentLevel.ToString();
    }
}