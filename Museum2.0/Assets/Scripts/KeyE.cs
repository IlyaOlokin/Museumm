using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyE : MonoBehaviour
{
    public GameObject target;
    private MeshRenderer renderer;
    public int appearZone;
    public bool boolc;
 
    void Start()
    {
        target = GameObject.Find("MainCamera");
        renderer = GetComponent<MeshRenderer>();
    }
   
    void Update()
    {
        boolc = Vector3.Distance(transform.position, target.transform.position) < appearZone;
        renderer.enabled = boolc;
        transform.LookAt(target.transform);
    }
}
