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
        //Vector3 movement = PlayerModel.PlayerSpeed * PlayerView.playerMoveVertical * Time.deltaTime * PlayerView.transform.forward;
        //PlayerView.Rigidbody.MovePosition(PlayerView.Rigidbody.position + movement);
        Vector3 direction = new Vector3(PlayerView.playerMoveHorizontal, 0f, PlayerView.playerMoveVertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(PlayerView.transform.eulerAngles.y, targetAngle, ref PlayerView.turnSmoothVelocity, PlayerView.turnSmoothTime);
            PlayerView.transform.rotation = Quaternion.Euler(0f, angle, 0f);
            PlayerView.CharacterController.Move(direction * PlayerModel.PlayerSpeed * Time.deltaTime);
        }
    }
}
