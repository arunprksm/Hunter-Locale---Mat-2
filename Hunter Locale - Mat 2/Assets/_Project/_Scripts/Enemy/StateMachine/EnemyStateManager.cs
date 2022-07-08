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
    internal EnemyTakingHitState EnemyTakingHitState = new EnemyTakingHitState();

    public EnemyView EnemyView;
    public PlayerView PlayerView;
    public FieldOfView FOV;
    public NavMeshAgent agent;
    public List<EnemyWaypoint> wayPoints;
    internal Transform player;
    public float distToPlayer;
    public float attackRange;
    public float rotationSpeed;

    public float timeBetweenAttack = 2f;
    public bool isAlreadyAttacked = false;

    private void Start()
    {
        currentState = EnemyPatrollingState;
        currentState.EnterState(this);
        CheckEnemy();
    }
    private void Update()
    {
        CheckPlayer();
        if(!EnemyView.isEnemyDead)
        currentState.UpdateState(this);
    }
    private void LateUpdate()
    {
        player = FOV.playerRef.transform;
        PlayerView = GetComponent<PlayerView>();
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
