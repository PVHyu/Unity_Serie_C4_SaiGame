using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SliderAbstract : SaiMonoBehaviour
{
    [SerializeField] protected Slider slider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if(this.slider != null) return;
        this.slider = GetComponentInChildren<Slider>();
        Debug.Log(transform.name + " : LoadSlider", gameObject);
    }
}