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

    // EnemyHead head = new EnemyHead();
    // EnemyHeart heart = new EnemyHeart();

    private void FixedUpdate()
    {
        this.TestClass();
    }

    void TestClass()
    {
        this.SetHP(0);
        string logMessage = this.GetName() + ": " + this.GetCurrentHP() + " " + this.IsDead();
        Debug.Log(logMessage);
    }

    public virtual bool IsDead()
    {
        if(this.currentHp > 0) this.isDead = false;
        else this.isDead = true;   

        // if(this.currentHp <= 0) this.isDead = true;
        // else this.isDead = false;
        return this.isDead;
    }

    public abstract string GetName();

    public void Moving()
    {
        string logMessage = this.GetName() + " Moving";
        Debug.Log(logMessage);
    }

    float GetWeight()
    {
        return this.weight;
    }

    public virtual int GetCurrentHP()
    {
        return this.currentHp;
    }

    public virtual void SetHP(int newHP)
    {
        this.currentHp = newHP;
    }
}
