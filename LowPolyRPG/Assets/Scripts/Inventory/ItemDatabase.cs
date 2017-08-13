using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    public List<Item> items { get; set; }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else Debug.LogWarning("More than one ItemDatabase in the scene!");
    }

    void Start()
    {
        BuildDatabase();
    }

    private void BuildDatabase()
    {
        Debug.Log(Resources.Load<TextAsset>("JSON/items"));
        items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/items").ToString());
        Debug.Log(items[0].Name);
    }
}