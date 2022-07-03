using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : SingletonGenerics<ChestService>
{
    public ChestController SelectedController;

    public ChestController GetChest(ChestScriptableObject chestScriptableObject, ChestView chestView)
    {
        ChestModel chestModel = new ChestModel(chestScriptableObject);
        ChestController chestController = new ChestController(chestView, chestModel);
        return chestController;
    }

    public void OnClickStartTimer()
    {
        SelectedController.EnteringUnlockingState();
        ChestSystemManager.Instance.CloseUnlockChestPopup();
    }

    public void OpenNowButton()
    {
        SelectedController.EnteringUnlockedState();
        ChestSystemManager.Instance.CloseButton();
    }

    public void UseGemsButton()
    {
        if (CurrencyManager.Instance.gems > SelectedController.GetGemCost())
        {
            CurrencyManager.Instance.DecreaseGems(valueToDecrease: SelectedController.GetGemCost());
            OpenNowButton();
        }
        else if (CurrencyManager.Instance.gems < SelectedController.GetGemCost())
        {
            Debug.Log("Gem Is Not Enough");
        }
    }
}
