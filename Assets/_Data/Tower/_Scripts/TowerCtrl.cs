using System;
using UnityEngine;

public class TowerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform rotator;
    public Transform Rotator => rotator;
    [SerializeField] protected TowerTargeting towerTargeting;
    public TowerTargeting TowerTargeting => towerTargeting;
    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner => bulletSpawner;
    [SerializeField] protected Bullet bullet;
    public Bullet Bullet => bullet; 

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadTowerTargeting();
        this.LoadBulletSpawner();
        this.LoadBullet();
    }

    protected virtual void LoadModel()
    {
        if(this.model != null) return;
        this.model = transform.Find("Model");
        this.model.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        this.rotator = this.model.Find("Head");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    
    protected virtual void LoadTowerTargeting()
    {
        if(this.towerTargeting != null) return;
        this.towerTargeting = this.transform.GetComponentInChildren<TowerTargeting>();
    }

    protected virtual void LoadBulletSpawner()
    {
        if(this.bulletSpawner != null) return;
        this.bulletSpawner = FindObjectsByType<BulletSpawner>()[0];
    }

    protected virtual void LoadBullet()
    {
        if(this.bullet != null) return;
        this.bullet = this.transform.GetComponentInChildren<Bullet>();
    }
}