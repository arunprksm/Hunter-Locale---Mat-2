using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : SingletonGenerics<CurrencyManager>
{
    public int coins;
    public int gems;


    private void Start()
    {
        coins = GameManager.Instance.GetInt("Coins");
        gems = GameManager.Instance.GetInt("Gems");
        ChestSystemManager.Instance.UpdateGemsUI(gems);
        ChestSystemManager.Instance.UpdateCoinsUI(coins);
    }
    public void IncreaseCoins(int valueToIncrease)
    {
        coins += valueToIncrease;
        GameManager.Instance.SetInt("Coins", coins);
        ChestSystemManager.Instance.UpdateCoinsUI(coins);
    }
    public void DecreaseCoins(int valueToDecrease)
    {
        coins -= valueToDecrease;
        GameManager.Instance.SetInt("Coins", coins);
        ChestSystemManager.Instance.UpdateCoinsUI(coins);
    }
    public void IncreaseGems(int valueToIncrease)
    {
        gems += valueToIncrease;
        GameManager.Instance.SetInt("Gems", gems);

        ChestSystemManager.Instance.UpdateGemsUI(gems);
    }
    public void DecreaseGems(int valueToDecrease)
    {
        gems -= valueToDecrease;
        GameManager.Instance.SetInt("Gems", gems);
        ChestSystemManager.Instance.UpdateGemsUI(gems);
    }
}
