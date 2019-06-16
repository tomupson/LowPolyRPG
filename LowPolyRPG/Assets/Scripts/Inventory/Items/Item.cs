using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public List<StatBonus> StatAdditives;
    public string Slug;
    public Sprite Icon;
    public string Name;
    [TextArea(3, 5)]
    public string Description;
    public bool IsDefaultItem;
    public string ActionName;
}
