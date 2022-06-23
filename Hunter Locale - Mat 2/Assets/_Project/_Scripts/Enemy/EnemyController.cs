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
        //OnEnableFunction();
    }
    internal void Gravitycontrol()
    {
        EnemyView.Velocity.y += EnemyView.gravity * Time.deltaTime * 2;
        EnemyView.EnemyCharacterController.Move(EnemyView.Velocity * Time.deltaTime);
    }
}