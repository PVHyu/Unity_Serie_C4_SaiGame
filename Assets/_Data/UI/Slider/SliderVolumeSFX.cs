using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeSFX : SliderAbstract
{
    protected override void OnSliderValueChanged(float value)
    {
        SoundManager.Instance.VolumeSFXUpdating(value);
    }
}