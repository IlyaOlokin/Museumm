using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBoard : MonoBehaviour
{
    public Text itemName;
    public Text itemInfo;

    public void Update()
    {
        if (Input.anyKeyDown)
        {
            GetClosed();
        }
    }

    public void GetActivated(GameObject invSlot)
    {
        gameObject.SetActive(true);
        itemName.text = invSlot.GetComponent<InvSlot>().itemName;
        itemInfo.text = invSlot.GetComponent<InvSlot>().itemInfo;
    }

    public void GetClosed()
    {
        gameObject.SetActive(false);
    }
}
