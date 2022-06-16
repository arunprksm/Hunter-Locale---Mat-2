using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotView : MonoBehaviour
{
    public ChestView ChestView;
    public bool chestIsEmpty;
    public ChestController ChestController;

    private void Start()
    {
        chestIsEmpty = true;
    }

    public void SpawnRandomChest(ChestScriptableObject chestScriptableObject)
    {
        ChestController = ChestService.Instance.GetChest(chestScriptableObject, ChestView);
        chestIsEmpty = false;
    }
}
