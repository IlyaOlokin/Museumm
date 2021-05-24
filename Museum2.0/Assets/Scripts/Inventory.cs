using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    public GameObject[] slots;

    public void AddItem(GameObject item)
    {
        GameObject emptySlot = FindEmptySlot();
        emptySlot.GetComponent<InvSlot>().GetItem(item);
    }

    private GameObject FindEmptySlot()
    {
        foreach (var slot in slots)
        {
            if (!slot.GetComponent<InvSlot>().containsItem)
            {
                return slot;
            }
        }

        return null;
    }
}
