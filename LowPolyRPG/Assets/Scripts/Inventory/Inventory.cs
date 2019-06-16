using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int inventorySpace = 20;

    public List<Item> items = new List<Item>();

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one Inventory instance in the scene!");
            return;
        }

        instance = this;
    }

    public bool AddItem(Item item)
    {
        if (!item.IsDefaultItem)
        {
            if (items.Count >= inventorySpace)
            {
                Debug.Log("No room in inventory...");
                return false;
            }

            items.Add(item);

            if (onItemChangedCallback != null) // Ensure events are subscribed to this callback.
            {
                onItemChangedCallback.Invoke(); // Refresh UI.
            }

            return true;
        } else
        {
            Debug.Log("Item is default item");
            // TO DO: Alerts List: Add "Cannot pickup default item" fade-in text.
            AlertManager.instance.PushAlert(new Alert("ITEM", "Cannot pickup default item.", 2f));
            return false;
        }
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }

        if (onItemChangedCallback != null) // Ensure events are subscribed to this callback.
        {
            onItemChangedCallback.Invoke(); // Refresh UI.
        }
    }
}