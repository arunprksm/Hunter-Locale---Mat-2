using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrollingState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemyStateManager)
    {
        EnemyPatrol(enemyStateManager);
    }


    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        //if (enemyStateManager.agent.remainingDistance <= enemyStateManager.agent.stoppingDistance)
        //{
        //    enemyStateManager.agent.SetDestination(enemyStateManager.wayPoints[UnityEngine.Random.Range(0, enemyStateManager.wayPoints.Count)].transform.position);
        //}

        if (enemyStateManager.FOV.canSeePlayer)
        {
            enemyStateManager.SwitchState(enemyStateManager.EnemyChaseState);
        }
    }
    private void EnemyPatrol(EnemyStateManager enemyStateManager)
    {
        //enemyStateManager.agent.SetDestination(enemyStateManager.wayPoints[UnityEngine.Random.Range(0, enemyStateManager.wayPoints.Count)].transform.position);
    }
}
