using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    public ChestController ChestController;
    internal ChestState currentState;

    public Button FillChestButton;
    public Sprite EmptyChestSprite;

    private void Start()
    {
        InitializeEmptyChestFunction();
    }
    public void InitializeEmptyChestFunction()
    {
        FillChestButton.image.sprite = EmptyChestSprite;
        currentState = ChestState.None;
    }

    public void ChestButtonClick()
    {
        if(ChestController != null)
        ChestController.ChestButtonClick_Controller();
    }
}
