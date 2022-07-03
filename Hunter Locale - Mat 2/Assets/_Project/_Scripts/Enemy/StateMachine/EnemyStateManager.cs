using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    internal EnemyBaseState currentState;
    internal EnemyPatrollingState EnemyPatrollingState = new EnemyPatrollingState();
    internal EnemyChaseState EnemyChaseState = new EnemyChaseState();
    internal EnemyAttackState EnemyAttackState = new EnemyAttackState();

    public EnemyView EnemyView;
    public FieldOfView FOV;
    public NavMeshAgent agent;
    public List<EnemyWaypoint> wayPoints; // = new List<EnemyWaypoint>();
    //public ArrayList wayPoints;
    internal Transform player;
    private void Start()
    {
        currentState = EnemyPatrollingState;
        currentState.EnterState(this);
        player = FOV.playerRef.transform;
        CheckEnemy();
    }
    private void Update()
    {
        CheckPlayer();
        currentState.UpdateState(this);
    }
    private void CheckPlayer()
    {
        if (!FOV.canSeePlayer)
        {
            currentState = EnemyPatrollingState;
            return;
        }
    }
    private void CheckEnemy()
    {
        wayPoints.Add(EnemyView.CreateWaypoint(-10));
        wayPoints.Add(EnemyView.CreateWaypoint(10));
        wayPoints = new List<EnemyWaypoint>();
    }
    internal void SwitchState(EnemyBaseState enemyBaseState)
    {
        currentState = enemyBaseState;
        currentState.EnterState(this);
    }
}
