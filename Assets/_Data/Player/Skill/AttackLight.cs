using UnityEngine;

public class AttackLight : AttackAbstract
{
    protected string effectName = "Fire1";
    protected SoundName shootSFXName = SoundName.LaserOneShoot;


    protected override void Attacking()
    {
        if(!InputManager.Instance.IsAttackLight()) return;

        AttackPoint attackPoint = this.GetAttackPoint();
        EffectCtrl effect = this.spawner.Spawn(this.GetEffect(), attackPoint.transform.position);
        EffectFlyAbstract effectFly = (EffectFlyAbstract)effect;
        effectFly.FlyToTarget.SetTarget(this.playerCtrl.CrosshairPointer.transform);

        effect.gameObject.SetActive(true);
        this.SpawnSound(attackPoint.transform.position);
    }

    protected virtual EffectCtrl GetEffect()
    {
        return this.prefabs.GetByName(this.effectName);
    }

    protected virtual void SpawnSound(Vector3 position)
    {
        SFXCtrl newSfx = SoundManager.Instance.CreateSFX(this.shootSFXName);
        newSfx.transform.position = position;
        newSfx.gameObject.SetActive(true);
    }
}