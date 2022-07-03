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
    }

    private EnemyController CreatePlayer(GameObject pos)
    {
        EnemyModel = new EnemyModel();
        EnemyController EnemyController = new EnemyController(EnemyView, EnemyModel, pos);
        return EnemyController;
    }

    //private Vector3 RandomPosition()
    //{
    //    float x, y, z;
    //    Vector3 pos;
    //    x = 0;
    //    y = 2;
    //    z = 0;
    //    pos = new Vector3(x, y, z);
    //    return pos;
    //}
}