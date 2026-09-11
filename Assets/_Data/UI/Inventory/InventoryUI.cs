using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : SaiSingleton<InventoryUI>
{
    protected bool isShow = true;
    bool IsShow => isShow;

    [SerializeField] protected ButtonItemInventory defaultItemInventoryUI;
    protected List<ButtonItemInventory> buttonItems = new();

    protected virtual void FixedUpdate()
    {
        this.ItemUpdating();
    }

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
        if(this.defaultItemInventoryUI != null) return;
        this.defaultItemInventoryUI = GetComponentInChildren<ButtonItemInventory>();
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
        this.defaultItemInventoryUI.gameObject.SetActive(false);
    }

    protected virtual void ItemUpdating()
    {
        InventoryCtrl itemInvCtrl = InventoryManager.Instance.Items();
        foreach(ItemInventory itemInventory in itemInvCtrl.Items)
        {
            ButtonItemInventory newItemUI = this.GetExistItem(itemInventory);
            if(newItemUI == null)
            {
                newItemUI = Instantiate(this.defaultItemInventoryUI);
                newItemUI.transform.parent = this.defaultItemInventoryUI.transform.parent;
                newItemUI.gameObject.SetActive(true);
            }
        }
    }

    protected virtual ButtonItemInventory GetExistItem(ItemInventory itemInventory)
    {
        foreach(ButtonItemInventory itemInvUI in this.buttonItems)
        {
            
        }
        return null;
    }
}