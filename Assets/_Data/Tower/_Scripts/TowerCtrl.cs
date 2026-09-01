using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    [SerializeField] protected List<FirePoint> firePoints = new();
    public List<FirePoint> FirePoints => firePoints;

    protected override void Awake()
    {
        base.Awake();
        this.HidePrefabs();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadTowerTargeting();
        this.LoadBulletSpawner();
        this.LoadBullet();
        this.LoadFirePoints();
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

    protected virtual void LoadFirePoints()
    {
        if(this.firePoints.Count > 0) return;
        FirePoint[] firePoints = this.transform.GetComponentsInChildren<FirePoint>();
        this.firePoints = new List<FirePoint>(firePoints);
        Debug.Log(this.firePoints[0].name + " is loaded at " + this.firePoints[0].transform.position, gameObject);
        Debug.Log(transform.name + ": LoadFirePoints", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        this.bullet.gameObject.SetActive(false);
    }
}