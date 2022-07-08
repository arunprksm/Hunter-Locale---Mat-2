using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    public EnemyController EnemyController;
    public EnemyWaypoint EnemyWaypoint;
    public EnemyStateManager EnemyStateManager;
    public Animator EnemyAnimator;
    internal Vector3 Velocity;
    public float gravity = -9.81f;
    public float groundedGravity = -10;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask, playerMask;
    public bool isGrounded;
    public PlayerView PlayerView;
    public int EnemyMaxHealth = 100;
    public int currentHealth;
    public bool isEnemyDead;

    public Transform[] attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 10;

    internal static string[] attacks;

    private void Start()
    {
        currentHealth = EnemyMaxHealth;
        isEnemyDead = false;
    }
    private void Update()
    {
        HandleGravity();
        if (!EnemyStateManager.isAlreadyAttacked) AttackControl();
    }
    private void LateUpdate()
    {
        PlayerView = FindObjectOfType<PlayerView>();
    }
    private void HandleGravity()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = groundedGravity;
        }
        EnemyController.Gravitycontrol();
    }
    
    internal void EnemyAttackFunction()
    {
        EnemyController.EnemyAttack();
    }

    internal EnemyWaypoint CreateWaypoint(int position)
    {
        EnemyWaypoint EnemyWaypoint = new(this, position);
        return EnemyWaypoint;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(!isEnemyDead)
        EnemyAnimator.SetTrigger("GettingHit");

        if (currentHealth <= 0)
        {
            EnemyDead();
        }
    }
    public void AttackControl()
    {
        Collider[] hitEnemies;
        for (int i = 0; i < attackPoint.Length; i++)
        {
            hitEnemies = Physics.OverlapSphere(attackPoint[i].position, attackRange, playerMask);
            foreach (Collider EnemyView in hitEnemies)
            {
                PlayerView.TakeDamage(attackDamage);
            }
        }
    }
    private void EnemyDead()
    {
        isEnemyDead = true;
        EnemyAnimator.SetBool("EDie", true);
    }
}