using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController
{
    public ChestView ChestView { get; private set; }
    public ChestModel ChestModel { get; private set; }


    public ChestController(ChestView chestView, ChestModel chestModel)
    {
        ChestView = chestView;
        ChestModel = chestModel;
        ChestView.ChestController = this;
        InitializeLockedChestfunction();
    }

    private void InitializeLockedChestfunction()
    {
        ChestView.FillChestButton.image.sprite = ChestModel.ChestSprite_Locked;
        ChestView.currentState = ChestState.Locked;
    }
    internal void ChestButtonClick_Controller()
    {

        if (ChestView.currentState == ChestState.Locked)
        {

        }
        else if (ChestView.currentState == ChestState.Unlocking)
        {

        }
        else if (ChestView.currentState == ChestState.UnLocked)
        {

        }
    }
}