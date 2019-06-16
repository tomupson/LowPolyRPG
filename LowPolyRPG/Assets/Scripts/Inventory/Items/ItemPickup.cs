using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup()
    {
        Debug.Log(string.Format("Picking up {0}", item.Name));
        if(Inventory.instance.AddItem(item))
        {
            item.StatAdditives.ForEach(x =>
            {
                BaseStat associatedStat = player.GetStatWithName(x.AssociatedStatName);
                if (associatedStat != null)
                {
                    associatedStat.BaseStatBonuses.Add(x);
                }
            });

            AlertManager.instance.PushAlert(new Alert("ITEM", "You picked up " + item.Name, 4f));

            Destroy(gameObject);
        }
    }
}