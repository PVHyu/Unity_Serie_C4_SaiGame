using UnityEngine;

public class TowerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
    }

    protected virtual void LoadModel()
    {
        if(this.model != null) return;
        this.model = transform.Find("Model");
        this.model.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        this.rotator = this.model.Find("Head");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
}