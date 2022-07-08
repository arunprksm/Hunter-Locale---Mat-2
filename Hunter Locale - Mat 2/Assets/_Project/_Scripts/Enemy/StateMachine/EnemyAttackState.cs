using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemyStateManager)
    {
        enemyStateManager.RotateTowards(enemyStateManager.player);
    }

    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        enemyStateManager.RotateTowards(enemyStateManager.player);
        AttackFunction(enemyStateManager);
        if (enemyStateManager.distToPlayer > enemyStateManager.attackRange)
        {
            enemyStateManager.SwitchState(enemyStateManager.EnemyChaseState);
        }
    }

    private void AttackFunction(EnemyStateManager enemyStateManager)
    {
        if (!enemyStateManager.isAlreadyAttacked)
        {
            enemyStateManager.EnemyView.EnemyAttackFunction();
            enemyStateManager.EnemyView.AttackControl();
            enemyStateManager.isAlreadyAttacked = true;
            enemyStateManager.StartCoroutine(ResetAttack(enemyStateManager));
        }
    }

    private IEnumerator ResetAttack(EnemyStateManager enemyStateManager)
    {
        yield return new WaitForSecondsRealtime(enemyStateManager.timeBetweenAttack);
        enemyStateManager.isAlreadyAttacked = false;
    }
}
