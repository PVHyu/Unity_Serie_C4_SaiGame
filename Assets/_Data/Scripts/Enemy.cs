using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    int currentHp = 90;
    int maxHp = 100; 
    float weight = 2.5f;
    string name = "Zombie";
    bool isDead = false;

    EnemyHead head = new EnemyHead();
    EnemyHeart heart = new EnemyHeart();

    void Moving()
    {
        
    }

    float GetWeight()
    {
        return this.weight;
    }

    int GetCurrentHp()
    {
        return this.currentHp;
    }
}
