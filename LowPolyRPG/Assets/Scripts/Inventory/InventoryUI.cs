using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;

    void Awake()
    {
        Inventory.instance.onItemChangedCallback += this.OnInventoryChange;
    }

    void Start()
    {
        inventoryPanel = this.gameObject;
        inventoryPanel.SetActive(false);
    }

    public void ShowInventory()
    {
        inventoryPanel.SetActive(false);
    }

    void OnInventoryChange()
    {
        Debug.Log("HI");
    }
}