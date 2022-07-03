using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : SingletonGenerics<CurrencyManager>
{
    public int coins;
    public int gems;


    private void Start()
    {
        coins = GameManager.Instance.PlayerPrefs_GetInt("Coins");
        gems = GameManager.Instance.PlayerPrefs_GetInt("Gems");
        ChestSystemManager.Instance.UpdateGemsUI(gems);
        ChestSystemManager.Instance.UpdateCoinsUI(coins);
    }
    public void IncreaseCoins(int valueToIncrease)
    {
        coins += valueToIncrease;
        GameManager.Instance.PlayerPrefs_SetInt("Coins", coins);
        ChestSystemManager.Instance.UpdateCoinsUI(coins);
    }
    public void DecreaseCoins(int valueToDecrease)
    {
        coins -= valueToDecrease;
        GameManager.Instance.PlayerPrefs_SetInt("Coins", coins);
        ChestSystemManager.Instance.UpdateCoinsUI(coins);
    }
    public void IncreaseGems(int valueToIncrease)
    {
        gems += valueToIncrease;
        GameManager.Instance.PlayerPrefs_SetInt("Gems", gems);

        ChestSystemManager.Instance.UpdateGemsUI(gems);
    }
    public void DecreaseGems(int valueToDecrease)
    {
        gems -= valueToDecrease;
        GameManager.Instance.PlayerPrefs_SetInt("Gems", gems);
        ChestSystemManager.Instance.UpdateGemsUI(gems);
    }
}
