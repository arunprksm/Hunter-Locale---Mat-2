using UnityEngine;

public class ChestModel
{
    public string ChestName { get; }
    //public string ChestTypeName { get; }
    public Sprite ChestSprite_Locked { get; }
    public Sprite ChestSprite_Unlocking { get; }
    public Sprite ChestSprite_Unlocked { get; }
    public int MinCoins { get; }
    public int MaxCoins { get; }
    public int MinGems { get; }
    public int MaxGems { get; }
    public float UnlockTimer { get; }

    public ChestModel(ChestScriptableObject chestScriptableObject)
    {
        ChestName = chestScriptableObject.ChestName;
        //ChestTypeName = chestScriptableObject.ChestTypeName;
        ChestSprite_Locked = chestScriptableObject.ChestSpriteLocked;
        ChestSprite_Unlocking = chestScriptableObject.ChestSpriteUnlocking;
        ChestSprite_Unlocked = chestScriptableObject.ChestSpriteUnlocked;
        MinCoins = chestScriptableObject.MinCoins;
        MaxCoins = chestScriptableObject.MaxCoins;
        MinGems = chestScriptableObject.MinGems;
        MaxGems = chestScriptableObject.MaxGems;
        UnlockTimer = chestScriptableObject.UnlockTimer;
    }
}