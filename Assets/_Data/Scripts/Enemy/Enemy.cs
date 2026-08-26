using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Enemy : MonoBehaviour
{
    int currentHp = 90;
    int maxHp = 100; 
    float weight = 2.5f;
    float minWeight = 1f;
    float maxWeight = 10f;
    bool isDead = false;
    bool isBoss = true;

    void Reset()
    {
        this.InitData();
    }

    void OnEnable()
    {
        this.InitData();
    }

    private void FixedUpdate()
    {
        //this.TestClass();
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
        return this.isDead;
    }

    public abstract string GetName();

    public virtual string GetObjName()
    {
        return transform.name;
    }

    protected virtual void InitData()
    {
        this.weight = this.GetRandomWeight();
    }

    protected virtual float GetRandomWeight()
    {
        return Random.Range(minWeight, maxWeight);
    }

    public void Moving()
    {
        string logMessage = this.GetName() + " Moving";
        Debug.Log(logMessage);
    }

    public float GetWeight()
    {
        return this.weight;
    }

    public virtual float GetMaxWeight()
    {
        return this.maxWeight;
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
