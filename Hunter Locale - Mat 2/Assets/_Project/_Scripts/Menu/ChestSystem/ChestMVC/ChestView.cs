using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ChestView : MonoBehaviour
{
    public ChestController ChestController;
    internal ChestState currentState;
    public SlotView slotView;

    public Button FillChestButton;
    public Sprite EmptyChestSprite;


    public TextMeshProUGUI TimerText;
    internal bool TimerRunning;
    public float IsTimerRunning;
    public float unlockTimer;

    private void Start()
    {
        InitializeEmptyChestFunction();
    }
    private void Update()
    {
        if (TimerRunning)
        {
            ChestController.TimerCountFunction();
        }
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
