using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public PlayerController PlayerController;
    public Rigidbody Rigidbody;
    public Animator Animator; 
    public CharacterController CharacterController;
    internal Vector3 Velocity;
    public float gravity = -9.81f;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

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

    private void Awake()
    {
        InitializeComponents();
    }

    private void Start()
    {

    }
    private void Update()
    {
        PlayerInput();
        HandleGravity();
    }

    private void HandleGravity()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }
        PlayerController.Gravitycontrol();
    }

    private void InitializeComponents()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
    }

    public void PlayerInput()
    {
        playerMoveVertical = Input.GetAxisRaw("Vertical");
        playerMoveHorizontal = Input.GetAxisRaw("Horizontal");
        fire1 = Input.GetMouseButtonDown(0);
        fire0 = Input.GetMouseButton(0);
        fire2 = Input.GetMouseButtonUp(0);
    }
    private void FixedUpdate()
    {
        ControlPlayer();
    }
    private void ControlPlayer()
    {
        PlayerController.PlayerMovement();
    }
}
