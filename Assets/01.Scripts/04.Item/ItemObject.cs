public class ItemObject : InteractableObject
{
    public ItemData data;

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
                // player의 수류탄 수 증가
                break;
            case ItemType.MAGAZINE:
                // player의 탄창 수 증가
                break;
            case ItemType.REPAIR_KIT:
                // player의 수리키트 수 증가
                break;
        }
        Destroy(this.gameObject);
    }
}