using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Enemy : MonoBehaviour
{
    int currentHp = 90;
    int maxHp = 100; 
    float weight = 2.5f;
    bool isDead = false;
    bool isBoss = true;

    EnemyHead head = new EnemyHead();
    EnemyHeart heart = new EnemyHeart();

    void TestClass()
    {
        this.GetName();
    }

    protected abstract string GetName();

    public void Moving()
    {
        string logMessage = this.GetName() + " Moving";
        Debug.Log(logMessage);
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
