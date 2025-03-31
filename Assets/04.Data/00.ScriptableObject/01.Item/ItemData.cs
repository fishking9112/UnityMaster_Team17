using UnityEngine;

public enum ItemType
{
    GRENADE,
    MAGAZINE,
    REPAIR_KIT,
}

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public ItemType itemType;
    public string itemName;
    public string itemDescription;
    public int value;
    public GameObject itemPrefab;
}
