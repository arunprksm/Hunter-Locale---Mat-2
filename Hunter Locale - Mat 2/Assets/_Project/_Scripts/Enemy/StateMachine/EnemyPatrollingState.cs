using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrollingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemyStateManager)
    {

    }


    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        if (enemyStateManager.FOV.canSeePlayer)
        {
            enemyStateManager.SwitchState(enemyStateManager.EnemyChaseState);
        }
    }
}
