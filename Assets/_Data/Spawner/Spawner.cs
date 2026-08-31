using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Spawner : SaiMonoBehaviour
{
    public virtual Bullet Spawn(Bullet bulletPrefab)
    {
        Debug.Log("Bullet is spawning");
        Bullet newObject = Instantiate(bulletPrefab);
        return newObject;
    }

    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);
        return newObject;
    }
}