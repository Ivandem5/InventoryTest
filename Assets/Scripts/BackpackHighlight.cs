using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackHighlight : MonoBehaviour
{
    
    [SerializeField] private Renderer objectRenderer;
    private Color originalColor;

    public Color highlightColor = Color.green;

    void Start()
    {        
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color; 
        }
    }

    void OnMouseEnter()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = highlightColor; 
        }
    }

    void OnMouseExit()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor; 
        }
    }
}
