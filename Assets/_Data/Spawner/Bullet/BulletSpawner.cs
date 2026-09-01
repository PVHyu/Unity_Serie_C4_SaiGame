using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletSpawner : Spawner
{
    public virtual Bullet Spawn(Bullet bulletPrefab)
    {
        Debug.Log("Bullet is spawning");
        Bullet newObject = Instantiate(bulletPrefab);
        newObject.Despawn.SetSpawner(this);
        return newObject;
    }

    public virtual Bullet Spawn(Bullet bulletPrefab, Vector3 position)
    {
        Bullet newBullet = Spawn(bulletPrefab);
        newBullet.transform.position = position;
        return newBullet;
    }
}