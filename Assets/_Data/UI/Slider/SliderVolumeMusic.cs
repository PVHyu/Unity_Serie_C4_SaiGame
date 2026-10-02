using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeMusic : SliderAbstract
{
    protected override void OnSliderValueChanged(float value)
    {
        SoundManager.Instance.VolumeMusicUpdating(value);
    }
}