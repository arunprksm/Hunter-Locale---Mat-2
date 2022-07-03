using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotView : MonoBehaviour
{
    public ChestView ChestView;
    public bool chestIsEmpty;

    private void Start()
    {
        chestIsEmpty = true;
    }
}
