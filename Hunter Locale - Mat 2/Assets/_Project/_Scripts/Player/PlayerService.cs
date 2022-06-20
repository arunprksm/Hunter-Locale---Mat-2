using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : MonoBehaviour
{
    public PlayerView PlayerView;
    private PlayerModel PlayerModel;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        CreatePlayer();
    }

    private PlayerController CreatePlayer()
    {
        PlayerModel = new PlayerModel();
        PlayerController playerController = new PlayerController(PlayerView, PlayerModel, RandomPosition());
        return playerController;
    }

    private Vector3 RandomPosition()
    {
        float x, y, z;
        Vector3 pos;
        x = 0;
        y = 2;
        z = 0;
        pos = new Vector3(x, y, z);
        return pos;
    }
}