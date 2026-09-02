using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Spawner<T> : SaiMonoBehaviour where T : PoolObject
{
    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected List<T> inPoolObjs = new List<T>();
    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);
        return newObject;
    }

     public virtual T Spawn(T prefab)
    {
        T newObject = Instantiate(prefab);
        return newObject;
    }

    public virtual T Spawn(T prefab, Vector3 position)
    {
        T newObject = Spawn(prefab);
        newObject.transform.position = position;
        return newObject;
    }

    public virtual void Despawn(Transform prefab)
    {
        Destroy(prefab.gameObject);
    }

    public virtual void Despawn(T obj)
    {
        if(obj is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            this.AddObjectToPool(obj);
        }
    }

    protected virtual void AddObjectToPool(T obj)
    {
        this.inPoolObjs.Add(obj);
    }
}