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
        // Save boolean using PlayerPrefs
        PlayerPrefs.SetInt("chestIsEmpty", chestIsEmpty ? 1 : 0);
    }

    public void SpawnRandomChest(ChestScriptableObject chestScriptableObject)
    {
        ChestController = ChestService.Instance.GetChest(chestScriptableObject, ChestView);
        chestIsEmpty = false;
        // Save boolean using PlayerPrefs
        PlayerPrefs.SetInt("chestIsEmpty", chestIsEmpty ? 1 : 0);
    }


}
