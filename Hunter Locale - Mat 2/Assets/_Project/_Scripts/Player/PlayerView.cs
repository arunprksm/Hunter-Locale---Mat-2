using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public PlayerController PlayerController;
    internal Rigidbody Rigidbody;
    public CharacterController CharacterController;

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
    }

    private void InitializeComponents()
    {
        Rigidbody = GetComponent<Rigidbody>();
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
