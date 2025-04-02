public class ItemObject : InteractableObject
{
    public ItemData data;

    public float respawnTiem;

    public override string GetNameText()
    {
        return data.itemName;
    }

    public override string GetDescriptionText()
    {
        return data.itemDescription;
    }

    public override void OnInteract()
    {
        switch (data.itemType)
        {
            case ItemType.GRENADE:
                GameManager.Instance.player.Condition.AddGrenade(data.value);
                break;
            case ItemType.MAGAZINE:
                GameManager.Instance.player.Condition.AddMagazine(data.value);
                break;
            case ItemType.REPAIR_KIT:
                GameManager.Instance.player.Condition.AddRepairKit(data.value);
                break;
        }
        
        gameObject.SetActive(false);

        Invoke("RespawnItem", respawnTiem);
    }

    private void RespawnItem()
    {
        gameObject.SetActive(true);
    }
}