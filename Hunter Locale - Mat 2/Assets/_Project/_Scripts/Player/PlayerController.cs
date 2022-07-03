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
        PlayerView.PlayerCharacterController.Move(PlayerView.Velocity * Time.deltaTime);
    }

    internal void PlayerAttack(EnemyView target)
    {
        
        PlayerView.attacks = new string[] { "Punch", "Combo", "Kick", "TakeDownAttack" };
        //Attack nothing in case target is null
        if (target == null && PlayerView.PlayerAnimator.GetBool("IsMoving"))
        {
            PlayerView.PlayerAnimator.SetBool("IsMoving", true);
            return;
        }

        if (PlayerView.PlayerAttackTypes.GetCurrentAttackType() == PlayerAttackTypes.AttackType.Punch)
        {
            string attackString = PlayerView.attacks[0];
            AttackType(attackString, 1f, target);
        }
        else if (PlayerView.PlayerAttackTypes.GetCurrentAttackType() == PlayerAttackTypes.AttackType.Combo)
        {
            string attackString = PlayerView.attacks[1];
            AttackType(attackString, 1f, target);
        }
        else if (PlayerView.PlayerAttackTypes.GetCurrentAttackType() == PlayerAttackTypes.AttackType.Kick)
        {
            string attackString = PlayerView.attacks[2];
            AttackType(attackString, 3f, target);
        }
        else if (PlayerView.PlayerAttackTypes.GetCurrentAttackType() == PlayerAttackTypes.AttackType.TakeDown)
        {
            string attackString = PlayerView.attacks[3];
            AttackType(attackString, 5f, target);
        }
    }


    void AttackType(string attackTrigger, float cooldown, EnemyView target)
    {
        PlayerView.PlayerAnimator.SetTrigger(attackTrigger);

        if (target == null)
            return;

        if (PlayerView.attackCoroutine != null)
            PlayerView.StopCoroutine(PlayerView.attackCoroutine);
        
        PlayerView.attackCoroutine = PlayerView.StartCoroutine(AttackCoroutine(cooldown));
    }
    IEnumerator AttackCoroutine(float duration)
    {
        PlayerView.isAttackingEnemy = true;
        yield return new WaitForSeconds(duration);
        PlayerView.isAttackingEnemy = false;
        yield return new WaitForSeconds(duration);
    }
}