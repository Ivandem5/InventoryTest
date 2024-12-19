using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemDragController : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 offset;
    private float objectZDepth;
    private bool isDragging = false;

    public LayerMask backpackLayer;      

    private IBackPack nearestBackpack;  
    private InventoryItem item;

    void Start()
    {
        mainCamera = Camera.main;
        item = GetComponent<InventoryItem>();
    }

    void OnMouseDown()
    {
        if (!item.isActive)
        {
            return;
        }
        isDragging = true;

        
        objectZDepth = mainCamera.WorldToScreenPoint(transform.position).z; // depth to object onMouseClick

        
        offset = transform.position - GetMouseWorldPosition(); //for smooth movement
        item.Pickup();
    }

    void OnMouseUp()
    {
        if (!item.isActive)
        {
            return;
        }
        isDragging = false;
        if (nearestBackpack != null)
        {
            nearestBackpack.AddItem(item);                       
            return;
        }
        item.Drop();
    }

    void Update()
    {
        if (isDragging&&item.isActive)
        {  
            FindNearestBackpack();            
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = objectZDepth; // Учитываем глубину объекта
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }

    void FindNearestBackpack()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, backpackLayer))
        {          
            if (hit.collider.TryGetComponent(out IBackPack backPack))
            {
                transform.position = Vector3.Lerp(transform.position, hit.transform.position + Vector3.up * backPack.itemOffsetY, Time.deltaTime * 10f);                
                nearestBackpack = backPack;
            }
        }
        else
        {
            Vector3 targetPosition = GetMouseWorldPosition() + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
            nearestBackpack = null;
        }
    }
}
