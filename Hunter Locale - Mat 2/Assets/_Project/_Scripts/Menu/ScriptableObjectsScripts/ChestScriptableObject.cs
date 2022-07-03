using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Chest Scriptable Objects", menuName = "Scriptable Objects/Create Chest Scriptable Object")]
public class ChestScriptableObject : ScriptableObject
{
    public string ChestName;
    public string ChestTypeName;
    public Sprite ChestSpriteLocked;
    public Sprite ChestSpriteUnlocking;
    public Sprite ChestSpriteUnlocked;
    public int MinCoins;
    public int MaxCoins;
    public int MinGems;
    public int MaxGems;
    public string ChestPopUp_CoinValue;
    public string ChestPopUp_GemValue;
    public float UnlockTimer;
}