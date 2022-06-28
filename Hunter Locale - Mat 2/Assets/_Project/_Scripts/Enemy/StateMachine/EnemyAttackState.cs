using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemyStateManager)
    {
        Debug.Log("EnemyAttackState");
    }

    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        enemyStateManager.RotateTowards(enemyStateManager.player);
        if (enemyStateManager.distToPlayer > enemyStateManager.attackRange)
        {
            enemyStateManager.SwitchState(enemyStateManager.EnemyChaseState);
        }
    }

    
}
