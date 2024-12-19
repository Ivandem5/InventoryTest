using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Backpack : MonoBehaviour, IBackPack
{
    [SerializeField] private float offset;   
    public UnityEvent<IInventoryItem> OnItemAdded;
    public UnityEvent<IInventoryItem> OnItemRemoved;
    public UnityEvent<bool> OnBackPackToggled;
    public float itemOffsetY => offset;

    private BackpackItemsContainer container;
    private List<IInventoryItem> items = new List<IInventoryItem>();

    private void Awake()
    {
        container = GetComponent<BackpackItemsContainer>();
    }

    public bool AddItem(IInventoryItem item)
    {
        RemoveItemByType(item.Type); // For test logic with more items
        if (!items.Contains(item))
        {
            items.Add(item);
            container.PutItem(item);
            OnItemAdded?.Invoke(item);            
            return true;
        }
        return false;
    }

    public bool RemoveItem(IInventoryItem item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            container.DropItem(item);
            OnItemRemoved?.Invoke(item);           
            return true;
        }
        return false;
    }

    public void RemoveItemByType(ItemType type)
    {
        IInventoryItem item = items.Find(obj => obj.Type == type);
        if (item != null) 
        {
            RemoveItem(item);
        }
    }

    private void OnMouseDown()
    {
        OnBackPackToggled?.Invoke(true);
    }

    private void OnMouseUp() 
    {
        OnBackPackToggled?.Invoke(false);
    }

   
}
