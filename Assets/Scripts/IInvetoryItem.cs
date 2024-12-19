using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem 
{
    string Name { get; }
    float Weight { get; }
    ItemType Type { get; }
    string Id { get; }
    Sprite Sprite { get; }

    void Pickup(); 
    void Drop();
    void MoveToHolder(Transform holder, float duration);
    void DropFromHolder(float dropForce);


}
