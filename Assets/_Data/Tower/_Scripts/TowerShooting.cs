using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected int currentFirePoint = 0;
    [SerializeField] protected float shootSpeed = 50.0f;
    [SerializeField] protected float targetLoadSpeed = 1.0f;
    [SerializeField] protected EnemyCtrl target;
    [SerializeField] protected float rotationSpeed = 2.0f;
    // [SerializeField] protected Bullet bullet;
     

    protected override void Start()
    {
        base.Start();
        this.TargetLoaing();
        this.Shooting();
    }

    protected void FixedUpdate()
    {
        this.Looking(); 
        
    }

    protected virtual void TargetLoaing()
    {
        Invoke(nameof(this.TargetLoaing), targetLoadSpeed);
        this.target = this.towerCtrl.TowerTargeting.Nearest;
    }

    protected virtual void Looking()
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

    protected virtual void Shooting()
    {
        Invoke(nameof(this.Shooting), shootSpeed);
        if(this.target == null) return;
        FirePoint firePoint = this.GetFirePoint();
        if(firePoint == null) return;
        Bullet newBullet = this.towerCtrl.BulletSpawner.Spawn(this.towerCtrl.Bullet, firePoint.transform.position);
        Vector3 rotatorDirection = this.towerCtrl.Rotator.forward;
        newBullet.transform.forward = rotatorDirection;
        newBullet.gameObject.SetActive(true);
    }

    protected virtual FirePoint GetFirePoint()
    {
        FirePoint firePoint = this.towerCtrl.FirePoints[currentFirePoint];
        
        return firePoint;
    }
}