using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Spawner : SaiMonoBehaviour
{
    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);
        return newObject;
    }
}