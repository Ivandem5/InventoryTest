using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemConfig", menuName = "Inventory/ItemConfig")]
public class ItemConfig : ScriptableObject
{
    public string itemName;         
    public float weight;            
    public ItemType type;             
    public string id;
    public Sprite sprite;
    public InventoryItem prefab;    
}
