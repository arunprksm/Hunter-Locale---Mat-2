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
        for (int i = 0; i < EnemyPosition.Length; i++)
        {
            CreatePlayer(EnemyPosition[i]);
        }
    }

    private EnemyController CreatePlayer(GameObject pos)
    {
        EnemyModel = new EnemyModel();
        EnemyController EnemyController = new(EnemyView, EnemyModel, pos);
        return EnemyController;
    }
}