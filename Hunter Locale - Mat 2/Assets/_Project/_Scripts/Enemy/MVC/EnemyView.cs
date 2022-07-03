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
    //public CharacterController EnemyCharacterController;
    internal Vector3 Velocity;
    public float gravity = -9.81f;
    public float groundedGravity = -10;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    private void Update()
    {
        HandleGravity();
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

    internal EnemyWaypoint CreateWaypoint(int position)
    {
        EnemyWaypoint EnemyWaypoint = new(this, position);
        return EnemyWaypoint;
    }
}