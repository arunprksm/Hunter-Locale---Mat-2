using System;
using System.Collections;
using System.Collections.Generic;
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

    internal string[] attacks;

    internal Coroutine attackCoroutine;

    internal bool isGrounded;

    internal float playerMoveVertical = 0f;
    internal float playerMoveHorizontal = 0f;
    internal bool fire1 = false;
    internal bool fire0 = false;
    internal bool fire2 = false;

    public float turnSmoothTime = 0.1f;
    internal float turnSmoothVelocity;

    public Rigidbody ShellPrefab;
    public Transform fireTransform;

    public bool fired;
    internal bool playerDead;
    internal bool isAttackingEnemy;
    public float attackCooldown = 2f;


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
        EnemyView = FindObjectOfType<EnemyView>();
        distToEnemy = Vector3.Distance(gameObject.transform.position, EnemyView.transform.position);
    }
    private void HandleGravity()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        //isGrounded = PlayerCharacterController.isGrounded;
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
        fire1 = Input.GetMouseButtonDown(0);
        fire0 = Input.GetMouseButton(0);
        fire2 = Input.GetMouseButtonUp(0);
    }
   
    private void ControlPlayer()
    {
        PlayerController.PlayerMovement();
        if(distToEnemy < 5f && !isAttackingEnemy)
        PlayerController.PlayerAttack(EnemyView);
    }
}
