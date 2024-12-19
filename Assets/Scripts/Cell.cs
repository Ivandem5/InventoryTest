using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ItemType type;
    public Image itemImage;
    public bool isChoosen = false;

    
    public void Clear()
    { 
        itemImage.sprite = null;
        isChoosen = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isChoosen = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isChoosen = false;
    }
}
