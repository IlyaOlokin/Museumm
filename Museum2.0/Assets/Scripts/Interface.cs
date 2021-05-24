using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public GameObject inventory;
    private Animator invAnim;
    private float progress;
    private Vector3 startPos;
    private Vector3 endPos;

    private void Start()
    {
        invAnim = inventory.GetComponent<Animator>();
    }

    public void ActivateInventory()
    {
        invAnim.SetTrigger("Activate");
    }

    public void HideInventory()
    {
        invAnim.SetTrigger("Hide");
    }
}
