using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected EnemyCtrl target;
    [SerializeField] protected float rotationSpeed = 2.0f;

    protected override void Start()
    {
        base.Start();
        this.TargetLoaing();
    }

    protected void FixedUpdate()
    {
        this.LookingAtTarget(); 
    }

    protected virtual void TargetLoaing()
    {
        Invoke(nameof(this.TargetLoaing), 1f);
        this.target = this.towerCtrl.TowerTargeting.Nearest;
    }

    protected virtual void LookingAtTarget()
    {
        if(this.target == null) return;
        Vector3 directionToTarget = this.target.TowerTargetable.transform.position - this.towerCtrl.Rotator.position;
        Vector3 newDirection = Vector3.RotateTowards(
            this.towerCtrl.Rotator.forward,
            directionToTarget,
            rotationSpeed * Time.fixedDeltaTime,
            0.0f
        );

        this.towerCtrl.Rotator.rotation = Quaternion.LookRotation(newDirection);
    }
}