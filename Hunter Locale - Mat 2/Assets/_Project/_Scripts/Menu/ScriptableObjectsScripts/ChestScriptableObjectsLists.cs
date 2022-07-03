using UnityEngine;

[CreateAssetMenu(fileName = "ChestScriptableObjectsLists", menuName = "Scriptable Objects/Create ChestScriptableObjectList")]
public class ChestScriptableObjectsLists : ScriptableObject
{
    [System.Serializable]
    public class ChestLayout
    {
        public ChestTypes ChestTypes;
        public ChestScriptableObject ChestScriptableObjectsList;
    }
    public ChestLayout[] ChestLayouts;
}