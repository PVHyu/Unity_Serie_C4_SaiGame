using UnityEngine;

public class AttackLight : AttackAbstract
{
    protected override void Attacking()
    {
        if(!InputManager.Instance.IsAttackLight()) return;

        AttackPoint attackPoint = this.GetAttackPoint();
        Debug.Log("Light Attack");
        Debug.Log("AttackPoint: " + attackPoint.transform.position);
    }
}