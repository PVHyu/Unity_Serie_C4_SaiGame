using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLevel : LevelAbstract
{
    [SerializeField] protected TowerCtrl towerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTowerCtrl();
    }

    protected virtual void LoadTowerCtrl()
    {
        if(this.towerCtrl != null) return;
        this.towerCtrl = GetComponentInParent<TowerCtrl>();
        Debug.Log(transform.name + ": LoadTowerCtrl", gameObject);
    }

   protected override bool DeductExp(int exp)
    {
        if(this.towerCtrl.TowerShooting.KillCount < exp) return false;
        this.towerCtrl.TowerShooting.KillCount -= exp;
        return true;
    }

    protected override int GetCurrentExp()
    {
        return this.towerCtrl.TowerShooting.KillCount;
    }
}