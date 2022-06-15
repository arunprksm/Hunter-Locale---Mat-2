using UnityEngine;

[CreateAssetMenu(fileName = "ChestScriptableObjectsLists", menuName = "ScriptableObjects/Create Chest Scriptable Object Lists")]
public class ChestScriptableObjectsLists : ScriptableObject
{
    [System.Serializable]
    public class ChestLayout
    {
        public ChestTypes ChestTypes;
        public ChestScriptableObjectsList ChestScriptableObjectsList;
    }
    public ChestLayout[] ChestLayouts;
}