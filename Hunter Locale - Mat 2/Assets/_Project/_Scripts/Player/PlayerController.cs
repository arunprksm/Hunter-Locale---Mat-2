using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{

    public PlayerView PlayerView { get; }
    public PlayerModel PlayerModel { get; }

    public PlayerController(PlayerView playerView, PlayerModel playerModel, Vector3 spawnPlayer)
    {
        PlayerModel = playerModel;
        PlayerView = GameObject.Instantiate(playerView);
        PlayerView.PlayerController = this;
        playerView.transform.position = spawnPlayer;
        //OnEnableFunction();
    }

    internal void PlayerMovement()
    {
        Vector3 direction = new Vector3(PlayerView.playerMoveHorizontal, 0f, PlayerView.playerMoveVertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(PlayerView.transform.eulerAngles.y, targetAngle, ref PlayerView.turnSmoothVelocity, PlayerView.turnSmoothTime);
            PlayerView.transform.rotation = Quaternion.Euler(0f, angle, 0f);
            PlayerView.PlayerCharacterController.Move(direction * PlayerModel.PlayerSpeed * Time.deltaTime);
            if (PlayerView.isGrounded)
            {
                PlayerView.PlayerAnimator.SetBool("IsMoving", true);
                //fall animation is false
            }
            else
            {
                PlayerView.PlayerAnimator.SetBool("IsMoving", false);
                //fall animation is true
            }
        }
        else
        {
            PlayerView.PlayerAnimator.SetBool("IsMoving", false);
            //fall animation is false
        }
    }

    internal void Gravitycontrol()
    {
        PlayerView.Velocity.y += PlayerView.gravity * Time.deltaTime * 2;
        PlayerView.PlayerCharacterController.Move(PlayerView.Velocity * Time.deltaTime );
    }
}
