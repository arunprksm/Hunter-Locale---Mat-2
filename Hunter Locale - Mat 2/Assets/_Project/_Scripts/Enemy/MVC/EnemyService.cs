using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    public EnemyView EnemyView;
    private EnemyModel EnemyModel;
    public GameObject[] EnemyPosition;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        CreatePlayer(EnemyPosition[0]);
        CreatePlayer(EnemyPosition[1]);
        CreatePlayer(EnemyPosition[2]);

    }

    private EnemyController CreatePlayer(GameObject pos)
    {
        EnemyModel = new EnemyModel();
        EnemyController EnemyController = new(EnemyView, EnemyModel, pos);
        return EnemyController;
    }
}