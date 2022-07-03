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
        enemyStateManager.RotateTowards(enemyStateManager.player);
        enemyStateManager.agent.SetDestination(enemyStateManager.player.position);
        enemyStateManager.EnemyView.EnemyAnimator.SetBool("Chase", true);
        enemyStateManager.EnemyView.EnemyAnimator.SetTrigger("EChase");
        CheckEnemyAttack(enemyStateManager);
    }

    private void CheckEnemyAttack(EnemyStateManager enemyStateManager)
    {
        if (enemyStateManager.distToPlayer <= enemyStateManager.attackRange)
        {
            enemyStateManager.EnemyView.EnemyAnimator.SetBool("Chase", false);
            enemyStateManager.SwitchState(enemyStateManager.EnemyAttackState);
        }
    }
}
