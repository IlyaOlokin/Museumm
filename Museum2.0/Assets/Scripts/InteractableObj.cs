using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    public Sprite image;
    public string itemName;
    [Multiline]
    public string itemInfo;

    private void OnMouseDown()
    {
        if (Mouse.DraggedItem == null)
        {
            transform.parent.GetComponent<SlotMarker>().DestroyObj();
            Destroy(gameObject);
        }
    }
}
