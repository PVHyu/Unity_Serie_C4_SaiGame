using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDespawn : Despawn<EnemyCtrl>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.isDespawnByTime = false;
    }
}