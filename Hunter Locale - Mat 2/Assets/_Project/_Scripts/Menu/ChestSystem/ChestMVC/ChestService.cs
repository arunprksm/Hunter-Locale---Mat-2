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
}
