using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
 using Image = UnityEngine.UI.Image;

public class InvSlot : MonoBehaviour
{
    public bool containsItem;
    public GameObject imageOfItem;
    public GameObject itemInSlot;
    public GameObject infoButton;

    public string itemName;
    public string itemInfo;

    private void OnMouseDown()
    {
        if (containsItem)
        {
            GiveItemAway();
        }
        else if (Mouse.DraggedItem != null)
        {
            GetItem(Mouse.DraggedItem);
            Mouse.DraggedItem = null;
        }
    }
    
    public void GetItem(GameObject item)
    {
        itemInSlot = item;
        imageOfItem.GetComponent<Image>().sprite = item.GetComponent<InteractableObj>().image;
        containsItem = true;
        infoButton.SetActive(true);
        itemName = item.GetComponent<InteractableObj>().itemName;
        itemInfo = item.GetComponent<InteractableObj>().itemInfo;
    }

    private void GiveItemAway()
    {
        Mouse.DraggedItem = itemInSlot;
        itemInSlot = null;
        imageOfItem.GetComponent<Image>().sprite = null;
        containsItem = !containsItem;
        infoButton.SetActive(false);
    }
}
