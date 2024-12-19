using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class BackpackUIPanel : MonoBehaviour
{
    [SerializeField] private List<Cell> cells;
    [SerializeField] private Backpack backpack;

    private void Awake()
    {
       
    }

    public void AddItems(IInventoryItem item)
    {
        Debug.Log(item.Type);
        Cell cell = cells.Find(obj => obj.type == item.Type);
        if (cell != null)
        { 
            cell.itemImage.sprite = item.Sprite;
        }
    }

    public void RemoveItems(IInventoryItem item)
    {
        Cell cell = cells.Find(obj => obj.type == item.Type);
        if (cell != null)
        {
            cell.Clear();
        }
    }

    public void SetView(bool value)
    {
        if (!value)
        {
            Cell cell = cells.Find(obj  => obj.isChoosen);
            if (cell != null)
            {
                backpack.RemoveItemByType(cell.type);
            }
        }
        gameObject.SetActive(value);
    }

}
