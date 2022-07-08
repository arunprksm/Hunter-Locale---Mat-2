using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public PlayerController PlayerController;
    public PlayerAttackTypes PlayerAttackTypes;
    public EnemyView EnemyView;
    private float distToEnemy;
    public Animator PlayerAnimator;
    public CharacterController PlayerCharacterController;

    internal Vector3 Velocity;
    public float gravity = -9.81f;
    public float groundedGravity = -10;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask enemyMask;

    internal string[] attacks;

    internal Coroutine attackCoroutine;

    internal bool isGrounded;

    internal float playerMoveVertical = 0f;
    internal float playerMoveHorizontal = 0f;

    public float turnSmoothTime = 0.1f;
    internal float turnSmoothVelocity;

    public Rigidbody ShellPrefab;
    public bool isPlayerAttacking;
    public Transform[] attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 1;

    public int PlayerMaxHealth = 100;
    public int currentHealth;
    internal bool playerDead;
    internal bool isAttackingEnemy;
    public float attackCooldown = 10f;
    private float targetCheckRadius = 5f;


    private void Start()
    {
        currentHealth = PlayerMaxHealth;
    }
    private void Update()
    {
        PlayerInput();
        HandleGravity();
    }
    private void FixedUpdate()
    {
        ControlPlayer();
    }

    private void LateUpdate()
    {
        PlayerAttackTypes = FindObjectOfType<PlayerAttackTypes>();
    }
    private void HandleGravity()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = groundedGravity;
        }
        PlayerController.Gravitycontrol();
    }

    public void PlayerInput()
    {
        playerMoveVertical = Input.GetAxisRaw("Vertical");
        playerMoveHorizontal = Input.GetAxisRaw("Horizontal");
    }
   
    private void ControlPlayer()
    {
        PlayerController.PlayerMovement();
        CheckEnemy();
        if(isPlayerAttacking) AttackControl();
    }

    private void CheckEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, targetCheckRadius, enemyMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i] == null)
            {
                isPlayerAttacking = false;
                return;
            }
            EnemyView = colliders[i].GetComponent<EnemyView>();
            distToEnemy = Vector3.Distance(gameObject.transform.position, EnemyView.transform.position);
            if (!EnemyView.isEnemyDead && distToEnemy < targetCheckRadius && !isAttackingEnemy && !EnemyView.EnemyStateManager.isAlreadyAttacked)
                PlayerController.PlayerAttack(EnemyView);
            SetEnemyView(EnemyView);
        }
    }
    public void SetEnemyView(EnemyView enemyView) => EnemyView = enemyView;
    public EnemyView GetEnemyView() => EnemyView;

    public void AttackControl()
    {
        Collider[] hitEnemies;
        for (int i = 0; i < attackPoint.Length; i++)
        {
            hitEnemies = Physics.OverlapSphere(attackPoint[i].position, attackRange, enemyMask);
            foreach (Collider Enemies in hitEnemies)
            {
                GetEnemyView().TakeDamage(attackDamage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (!playerDead)
            PlayerAnimator.SetTrigger("PGettingHit");

        if (currentHealth <= 0)
        {
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        playerDead = true;
        PlayerAnimator.SetBool("PDie", true);
    }

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < attackPoint.Length; i++)
        {
            if (attackPoint[i] == null)
            {
                return;
            }
            Gizmos.DrawSphere(attackPoint[i].position, attackRange);
        }
    }
}
