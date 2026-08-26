using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class EnemySort : MonoBehaviour
{
    List<Enemy> enemies = new();
    
    EnemyManager enemyManager;

    void Awake()
    {
        this.LoadComponents();
    }

    void Reset()
    {
        this.LoadComponents();
    }

    void Start()
    {
        this.Sorting();
    }

    protected virtual void LoadComponents()
    {
        if(this.enemyManager != null) return;
        this.enemyManager = GetComponent<EnemyManager>();
    }

    protected void Sorting()
    {
        this.enemies = this.enemyManager.Enemies;
        for(int i = 0; i < enemies.Count - 1; i++)
        {
            for(int j = i + 1; j < enemies.Count; j++)
            {
                if(this.enemies[i].GetWeight() > enemies[j].GetWeight()) 
                    (enemies[i], enemies[j]) = (enemies[j], enemies[i]);
            }
        }
    }
}