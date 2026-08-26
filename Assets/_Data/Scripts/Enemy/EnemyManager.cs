using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    List<Enemy> enemies = new();

    void Awake()
    {
        this.LoadEnemies();
    }

    protected virtual void LoadEnemies()
    {
        foreach(Transform childObj in transform)
        {
            Enemy enemy = childObj.GetComponent<Enemy>();
            if(enemy == null) continue;
            this.enemies.Add(enemy);
        }
    }
}