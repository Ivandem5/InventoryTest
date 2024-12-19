using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InventoryItem : MonoBehaviour, IInventoryItem
{

    [SerializeField] private ItemConfig config;
    private Rigidbody rb;
    private Collider coll;
    public string Name => config.itemName;
    public float Weight => config.weight;
    public ItemType Type => config.type;
    public string Id => config.id;
    public Sprite Sprite => config.sprite;

    public bool isActive;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        coll= rb.GetComponent<Collider>();
        isActive = true;
    }

    public void Initialize(ItemConfig config)
    {
        this.config = config;
    }

    public void Pickup()
    {
        rb.isKinematic = true;        
    }

    public void Drop()
    {
        rb.isKinematic = false;       
    }

    public void MoveToHolder(Transform holder, float duration)
    {
        BlockLogic(false);
        transform.SetParent(holder);
        transform.DOMove(holder.position,duration);
        transform.DOLocalRotate(Vector3.zero,duration);
    }

    public void DropFromHolder(float force)
    {
        transform.parent = null;
        BlockLogic(true);
        rb.AddForce(GenerateRandomVector()* force);
    }

    private Vector3 GenerateRandomVector()
    {
        int aDirection = Random.Range(-1, 1);
        int bDirection = Random.Range(-1, 1);
        return new Vector3(aDirection, 1, bDirection);
    }

    private void BlockLogic(bool value)
    {
        isActive = value;
        rb.isKinematic = !value;
        coll.enabled = value;
    }
    
}
