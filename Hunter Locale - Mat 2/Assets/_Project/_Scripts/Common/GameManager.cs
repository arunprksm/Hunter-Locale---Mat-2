using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonGenerics<GameManager> 
{
    public bool LevelCompleted;
    public int currentLevel = 0;
    public void NextScene()
    {
        currentLevel = GetInt("CurrentLevel");
        currentLevel++;
        SetInt("CurrentLevel", currentLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + GetInt("CurrentLevel"));
    }

    public void ClaimChest()
    {
        LevelCompleted = true;
        SceneManager.LoadScene(0);
    }

    public void SetGameManagerLevelCompleted(bool value) => LevelCompleted = value;
    //{
    //    LevelCompleted = value;
    //}
    public bool GetGameManagerLevelCompleted() => LevelCompleted;
    //{
    //    return LevelCompleted;
    //}

    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int GetInt(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
