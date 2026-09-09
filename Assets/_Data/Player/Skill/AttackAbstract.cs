using System.Threading;
using UnityEngine;

public abstract class AttackAbstract : SaiMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected void Update()
    {
        this.Attacking();
    }

    protected abstract void Attacking();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected void LoadPlayerCtrl()
    {
        if(this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }

    protected virtual AttackPoint GetAttackPoint()
    {
        return this.playerCtrl.Weapons.GetCurrentWeapon().AttackPoint;
    }
}