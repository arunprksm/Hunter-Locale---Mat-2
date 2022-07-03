using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakingHitState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemyStateManager)
    {
        
    }

    public override void UpdateState(EnemyStateManager enemyStateManager)
    {

        if (enemyStateManager.PlayerView.attacks[4] == "TakeDownAttack")
        {
            enemyStateManager.EnemyView.EnemyAnimator.SetTrigger("TakingDown");
        }
    }
}
