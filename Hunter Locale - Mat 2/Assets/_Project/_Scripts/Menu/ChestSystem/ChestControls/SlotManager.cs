using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : SingletonGenerics<SlotManager>
{
    [SerializeField] private SlotView[] SlotsView;
    [SerializeField] private ChestScriptableObjectsLists ChestScriptableObjectsLists;
    public GameManager GameManager;

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
        }
    }
    private int CheckSlotIsEmpty()
    {
        for (int i = 0; i < SlotsView.Length; i++)
        {
            if (SlotsView[i].chestIsEmpty)
            {
                return i;
            }
        }
        return -1;
    }
}
