using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ChestController
{
    public ChestView ChestView { get; private set; }
    public ChestModel ChestModel { get; private set; }
    public float timerValue;

    public ChestController(ChestView chestView, ChestModel chestModel)
    {
        ChestView = chestView;
        ChestModel = chestModel;
        ChestView.ChestController = this;
        InitializeLockedChestfunction();
        ChestView.unlockTimer = ChestModel.UnlockTimer;
    }

    private void InitializeLockedChestfunction()
    {
        ChestView.FillChestButton.image.sprite = ChestModel.ChestSprite_Locked;
        ChestView.currentState = ChestState.Locked;
        ChestView.TimerText.text = "Start timer";
        ChestView.currentState = ChestState.Locked;
    }

    public void InitializeUnLockingChestFunction()
    {
        ChestView.FillChestButton.image.sprite = ChestModel.ChestSprite_Unlocking;
        ChestView.currentState = ChestState.Unlocking;
    }
    public void InitializeUnLockedChestFunction()
    {
        ChestView.FillChestButton.image.sprite = ChestModel.ChestSprite_Unlocked;
        ChestView.currentState = ChestState.UnLocked;
    }


    internal void ChestButtonClick_Controller()
    {
        ChestService.Instance.SelectedController = this;
        if (ChestView.currentState == ChestState.Locked)
        {
            ChestSystemManager.Instance.Middle_UI.SetActive(false);
            ChestSystemManager.Instance.Buttons_UI.SetActive(false);
            ChestSystemManager.Instance.ChestPopUp.SetActive(true);
            ChestPopUpScript.Instance.SetChestPopUpValues(ChestModel, ChestView);
        }
        else if (ChestView.currentState == ChestState.Unlocking)
        {
            ChestSystemManager.Instance.OpenUnlockChestPopupUnlocking();
            ChestPopUpScript.Instance.SetChestPopUpValues(ChestModel, ChestView);
        }
        else if (ChestView.currentState == ChestState.UnLocked)
        {
            OpenChest();
        }
    }

    public void EnteringUnlockingState()
    {
        ChestView.unlockTimer = ChestModel.UnlockTimer;
        ChestView.TimerRunning = true;
        InitializeUnLockingChestFunction();
        TimerStartFunction();
    }
    public void EnteringUnlockedState()
    {
        InitializeUnLockedChestFunction();
        ChestView.unlockTimer = 0f;
        ChestView.TimerRunning = false;
        ChestView.TimerText.text = "OPEN CHEST!";
    }

    public void TimerCountFunction()
    {
        ChestView.unlockTimer -= Time.deltaTime;
        float minutes = Mathf.FloorToInt((int)ChestView.unlockTimer / 60);
        float seconds = Mathf.FloorToInt((int)ChestView.unlockTimer % 60);
        ChestView.TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public async void TimerStartFunction()
    {
        TimeSpan Ts = TimeSpan.FromSeconds(ChestView.unlockTimer);
        await Task.Delay(Ts);
        if (ChestView.currentState == ChestState.Unlocking)
        {
            EnteringUnlockedState();
        }
    }


    public void OpenChest()
    {
        ChestView.InitializeEmptyChestFunction();
        ReceiveChestRewards();
        ChestView.slotView.chestIsEmpty = true;
        ChestView.slotView.ChestController = null;
    }

    public void ReceiveChestRewards()
    {
        CurrencyManager.Instance.IncreaseCoins(ChestModel.CoinsReward);
        CurrencyManager.Instance.IncreaseGems(ChestModel.GemsReward);
    }
    public int GetGemCost()
    {
        //ChestView.unlockTimer = ChestModel.UnlockTimer;
        return (int)Mathf.Ceil(ChestView.unlockTimer / 2);
    }
}