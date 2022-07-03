using UnityEngine;

public class EnemyController
{
    public EnemyView EnemyView { get; }
    public EnemyModel EnemyModel { get; }

    public EnemyController(EnemyView enemyView, EnemyModel enemyModel, GameObject spawnPlayer)
    {
        EnemyModel = enemyModel;
        EnemyView = GameObject.Instantiate(enemyView);
        EnemyView.EnemyController = this;
        EnemyView.transform.position = spawnPlayer.transform.position;
    }
    internal void Gravitycontrol()
    {
        EnemyView.Velocity.y += EnemyView.gravity * Time.deltaTime * 2;
    }

    internal void EnemyAttack()
    {
        EnemyView.attacks = new string[] { "EPunch", "EHookPunch", "EKick" };

        int a = Random.Range(0, EnemyView.attacks.Length);
        string attackString = EnemyView.attacks[a];
        EnemyView.EnemyAnimator.SetTrigger(attackString);
    }
}