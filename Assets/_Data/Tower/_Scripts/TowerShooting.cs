using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected int currentFirePoint = 0;
    [SerializeField] protected float shootSpeed = 0.1f;
    [SerializeField] protected float targetLoadSpeed = 1.0f;
    [SerializeField] protected int totalKill = 0;
    [SerializeField] protected int killCount = 0;
    public int KillCount
    {
        get
        {
            return killCount;
        }
        set
        {
            killCount = value;
        }
    }
    [SerializeField] protected float rotationSpeed = 10.0f;
    [SerializeField] protected EnemyCtrl target;
    // [SerializeField] protected Bullet bullet;
     

    protected override void Start()
    {
        base.Start();
        this.TargetLoading();
        this.Shooting();
    }

    protected void FixedUpdate()
    {
        this.Looking(); 
        this.IsTargetDead();
    }

    protected virtual void TargetLoading()
    {
        Invoke(nameof(this.TargetLoading), targetLoadSpeed);
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

    protected virtual bool IsTargetDead()
    {
        if(this.target == null || !this.target.EnemyDamageReceiver.IsDead()) return false;
        this.KillCount++;
        this.totalKill++;
        this.target = null;
        return true;
    }
}