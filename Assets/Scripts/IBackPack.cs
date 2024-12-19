using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBackPack
{
    float itemOffsetY { get; }
    bool AddItem(IInventoryItem item);
    bool RemoveItem(IInventoryItem item);
    void RemoveItemByType(ItemType type);
}
