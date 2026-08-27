using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;

public class SaiMonoBehaviour : MonoBehaviour
{
    protected void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        
    }
}
