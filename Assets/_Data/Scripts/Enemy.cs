using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    int currentHp = 90;
    int maxHp = 100; 
    float weight = 2.5f;
    string enemyName = "Zombie";
    bool isDead = false;

    EnemyHead head = new EnemyHead();
    EnemyHeart heart = new EnemyHeart();

    void TestClass()
    {
        this.GetName();
    }

    string GetName()
    {
        return this.enemyName;
    }

    public void Moving()
    {
        string logMessage = this.GetName() + " Moving";
        Debug.Log("Moving");
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
