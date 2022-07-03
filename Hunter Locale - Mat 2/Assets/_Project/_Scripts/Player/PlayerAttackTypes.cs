using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAttackTypes : MonoBehaviour
{
    public Button[] Button;
    internal AttackType currentAttack;
    public FieldOfView FOV;
    private void Start()
    {
        currentAttack = AttackType.None;
    }
    private void Update()
    {
        ControlButtons();
    }

    private void LateUpdate()
    {
        FOV = FindObjectOfType<FieldOfView>();
        if (FOV.canSeePlayer)
        {
            Button[3].gameObject.SetActive(false);
            return;
        }
        Button[3].onClick.AddListener(() => SetAttack(AttackType.TakeDown));
    }
    public void ControlButtons()
    {
        Button[0].onClick.AddListener(() => SetAttack(AttackType.Punch));
        Button[1].onClick.AddListener(() => SetAttack(AttackType.Combo));
        Button[2].onClick.AddListener(() => SetAttack(AttackType.Kick));
    }

    private void SetAttack(AttackType currentAttackType)
    {
        currentAttack = currentAttackType;
    }
    public AttackType GetCurrentAttackType()
    {
        return currentAttack;
    }
    public enum AttackType
    {
        None,
        Punch,
        Combo,
        Kick,
        TakeDown
    }
}