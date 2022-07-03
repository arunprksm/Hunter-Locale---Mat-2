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
        currentLevel = PlayerPrefs_GetInt("CurrentLevel");
        currentLevel++;
        PlayerPrefs_SetInt("CurrentLevel", currentLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + PlayerPrefs_GetInt("CurrentLevel"));
    }

    public void ClaimChest()
    {
        LevelCompleted = true;
        SceneManager.LoadScene(0);
    }

    public void SetGameManagerLevelCompleted(bool value) => LevelCompleted = value;
    public bool GetGameManagerLevelCompleted() => LevelCompleted;
    public void PlayerPrefs_SetInt(string KeyName, int Value) => PlayerPrefs.SetInt(KeyName, Value);
    public int PlayerPrefs_GetInt(string KeyName) => PlayerPrefs.GetInt(KeyName);
    
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
