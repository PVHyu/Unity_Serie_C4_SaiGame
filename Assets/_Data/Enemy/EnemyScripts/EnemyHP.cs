using UnityEngine;
using UnityEngine.AI;

public class EnemyHP : SliderHP
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if(this.enemyCtrl != null) return;
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + " : LoadEnemyCtrl", gameObject);
    }

    protected override float GetValue()
    {
        return (float)this.enemyCtrl.EnemyDamageReceiver.CurrentHP / (float)this.enemyCtrl.EnemyDamageReceiver.MaxHP;
    }
}