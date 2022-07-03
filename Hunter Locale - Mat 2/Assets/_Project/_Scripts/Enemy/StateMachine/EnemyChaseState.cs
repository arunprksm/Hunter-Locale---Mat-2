using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemyStateManager)
    {
    }

    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        enemyStateManager.agent.SetDestination(enemyStateManager.player.position);
        CheckEnemyPatrol(enemyStateManager);
        CheckEnemyAttack(enemyStateManager);
    }

    private void CheckEnemyPatrol(EnemyStateManager enemyStateManager)
    {
        if (!enemyStateManager.FOV.canSeePlayer)
        {
            enemyStateManager.SwitchState(enemyStateManager.EnemyPatrollingState);
        }
    }

    private void CheckEnemyAttack(EnemyStateManager enemyStateManager)
    {
        //if (enemyStateManager.player.transform.position <= )
        //{
        //    enemyTankStateManager.SwitchState(enemyTankStateManager.attackState);
        //}
    }
}
