using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    public List<ItemConfig> itemConfigs;

    public InventoryItem CreateItem(string id, Vector3 position)
    {        
        ItemConfig config = itemConfigs.Find(item => item.id == id);
        if (config == null)
        {
            Debug.LogError($"ItemConfig with ID {id} doesn't exist!");
            return null;
        }
        
        InventoryItem item = Instantiate(config.prefab, position, Quaternion.identity);
        item.Initialize(config);        

        return item;
    }
}
