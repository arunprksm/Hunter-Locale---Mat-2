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
    public float distToPlayer;
    public float attackRange;
    public float rotationSpeed;

    private void Start()
    {
        currentState = EnemyPatrollingState;
        currentState.EnterState(this);
        CheckEnemy();
    }
    private void Update()
    {
        CheckPlayer();
        currentState.UpdateState(this);
    }
    private void LateUpdate()
    {
        player = FOV.playerRef.transform;
    }
    private void CheckPlayer()
    {
        if (player == null)
        {
            currentState = EnemyPatrollingState;
            return;
        }
        distToPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
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

    internal void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
