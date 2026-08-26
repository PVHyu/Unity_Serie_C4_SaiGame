using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity.IO.LowLevel.Unsafe;

public class EnemyManager : MonoBehaviour
{
    List<Enemy> enemies = new();
    public List<Enemy> Enemies => enemies;
    Enemy smallestEnemy;
    Enemy biggestEnemy;

    void Awake()
    {
        this.LoadEnemies();
    }

    void Start()
    {
        this.LoadSmallestEnemy();
        this.LoadBiggestEnemy();
    }

    protected virtual void LoadBiggestEnemy()
    {
        biggestEnemy = this.enemies[0];
        float biggestWeight = this.enemies[0].GetWeight();
        foreach (Enemy enemy in this.enemies)
        {
            if(biggestWeight < enemy.GetWeight()) 
            {
                biggestWeight = enemy.GetWeight();
                biggestEnemy = enemy;
            }
            Debug.Log(enemy.GetObjName() + " " + enemy.GetWeight());
        }
    }

    protected virtual void LoadSmallestEnemy()
    {
        smallestEnemy = this.enemies[0];
        float smallestWeight = this.enemies[0].GetWeight();
        foreach (Enemy enemy in this.enemies)
        {
            if(smallestWeight > enemy.GetWeight()) 
            {
                smallestWeight = enemy.GetWeight();
                smallestEnemy = enemy;
            }
            Debug.Log(enemy.GetObjName() + " " + enemy.GetWeight());
        }
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