using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMarker : MonoBehaviour
{
    public GameObject particles;
    public GameObject inventory;
    public GameObject objPref;
    private GameObject obj;
    public Vector3 objRotation;
    
    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        obj = transform.GetChild(0).transform.gameObject;
        objRotation = obj.transform.localEulerAngles;
    }

    public void DestroyObj()
    {
        Instantiate (particles, transform.position, Quaternion.identity);
        inventory.GetComponent<Inventory>().AddItem(objPref);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<SphereCollider>().enabled = true;
        objPref = null;
    }

    private void OnMouseDown()
    {
        objPref = Mouse.DraggedItem;
        Instantiate(objPref, transform, true);
        obj = transform.GetChild(0).transform.gameObject;
        obj.transform.localEulerAngles = objRotation;
        obj.transform.position = transform.position;
        Mouse.DraggedItem = null;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
    }
}
