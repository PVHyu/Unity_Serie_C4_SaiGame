using TMPro;
using UnityEngine;

public class ButtonItemInventory : ButttonAbstract
{
    [SerializeField] protected TextMeshProUGUI txtItemName;
    [SerializeField] protected TextMeshProUGUI txtItemCount;

    protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected virtual void FixedUpdate()
    {
        this.ItemUpdating();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemCount();
        this.LoadItemName();
    }

    protected virtual void LoadItemCount()
    {
        if(this.txtItemCount != null) return;
        this.txtItemCount = transform.Find("ItemCount").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadTexts", gameObject);
    }

    protected virtual void LoadItemName()
    {
        if(this.txtItemName != null) return;
        this.txtItemName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadTexts", gameObject);
    }

    public virtual void SetItem(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }

    protected override void OnClick()
    {
        Debug.Log("Click Item");
    }

    protected virtual void ItemUpdating()
    {
        this.txtItemName.text = this.itemInventory.itemName;
        this.txtItemCount.text = this.itemInventory.itemCount.ToString();
    }
}