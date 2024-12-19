using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackItemsContainer : MonoBehaviour
{
    [SerializeField] private List<ItemHolder> itemsHolder;
    public float moveDuration;
    public float dropForce;
    public void PutItem(IInventoryItem item)
    {
        ItemHolder itemHolder = itemsHolder.Find(obj => obj.itemType == item.Type);
        if (itemHolder != null)
        {
            item.MoveToHolder(itemHolder.transform,moveDuration);
        }
    }

    public void DropItem(IInventoryItem item) 
    {
        item.DropFromHolder(dropForce);
    }
}
