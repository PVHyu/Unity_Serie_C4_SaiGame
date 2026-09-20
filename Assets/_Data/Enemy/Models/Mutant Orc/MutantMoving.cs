using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MutantMoving : EnemyMoving
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.pathName = "path_0";
    }
}