using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : SingletonGenerics<SlotManager>
{
    [SerializeField] private SlotView[] SlotsView;
    [SerializeField] private ChestScriptableObjectsLists ChestScriptableObjectsLists;
    public GameManager GameManager;
    public int currentSlot = 0;

    private void Start()
    {
        currentSlot = GameManager.Instance.PlayerPrefs_GetInt("CurrentSlot");
        if(currentSlot > 2)
            GameManager.Instance.PlayerPrefs_SetInt("CurrentSlot", 0);
    }
    public void SpawnRandomChestOnClick()
    {
        int slot = CheckSlotIsEmpty();
        if (slot == -1)
        {
            Debug.Log("Slots are Full" + slot);
            return;
        }
        Debug.Log("Slots are Filling " + slot);
        SlotsView[slot].SpawnRandomChest(ChestScriptableObjectsLists.ChestLayouts[Random.Range(0, ChestScriptableObjectsLists.ChestLayouts.Length)].ChestScriptableObjectsList);
    }

    public void GetSlotView()
    {
        if (GameManager.GetGameManagerLevelCompleted())
        {
            SpawnRandomChestOnClick();
            GameManager.Instance.SetGameManagerLevelCompleted(false);
        }
    }
    private int CheckSlotIsEmpty()
    {
        for (int i = currentSlot; i < SlotsView.Length; i++)
        {
            if (SlotsView[i].chestIsEmpty)
            {
                GameManager.Instance.PlayerPrefs_SetInt("CurrentSlot", i);
                return i;
            }
        }
        return -1;
    }
}
