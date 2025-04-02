using UnityEngine;

public class ItemObject : InteractableObject
{
    public ItemData data;

    public float respawnTime;

    public override string GetNameText()
    {
        return data.itemName;
    }

    public override string GetDescriptionText()
    {
        return data.itemDescription;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            OnInteract();
        }
    }
    public override void OnInteract()
    {
        //switch (data.itemType)
        //{
        //    case ItemType.GRENADE:
        //        //GameManager.Instance.player.Condition.AddGrenade(data.value);
        //        break;
        //    case ItemType.MAGAZINE:
        //        //GameManager.Instance.player.Condition.AddMagazine(data.value);
        //        break;
        //    case ItemType.REPAIR_KIT:
        //        //GameManager.Instance.player.Condition.AddRepairKit(data.value);
        //        break;
        //}

        this.gameObject.SetActive(false);

        Invoke("RespawnItem", respawnTime);
    }

    private void RespawnItem()
    {
        this.gameObject.SetActive(true);
    }
}