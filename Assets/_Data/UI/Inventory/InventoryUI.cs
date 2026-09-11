using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : SaiSingleton<InventoryUI>
{
    protected bool isShow = true;
    bool IsShow => isShow;

    [SerializeField] protected ButtonItemInventory itemInventory;

    protected override void Start()
    {
        base.Start();
        this.Hide();
        this.HideDefaultItemInventory();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButtonItemInventory();
    }

    protected virtual void LoadButtonItemInventory()
    {
        if(this.itemInventory != null) return;
        this.itemInventory = GetComponentInChildren<ButtonItemInventory>();
    }

    public virtual void Show()
    {
        this.isShow = true;
        gameObject.SetActive(this.isShow);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
        this.isShow = false;
    }

    public virtual void Toggle()
    {
        if(this.isShow) this.Hide();
        else this.Show();
    }

    protected virtual void HideDefaultItemInventory()
    {
        this.itemInventory.gameObject.SetActive(false);
    }
}