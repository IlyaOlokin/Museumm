using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateStandZone : MonoBehaviour
{
    public GameObject camera;
    private CameraMove cm;
    public Transform CameraPosition;
    public Transform PointToLookAt;
    private GameObject cameraUI;
    private Interface _interface;
    public KeyE key;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraUI = GameObject.Find("Camera");
        _interface = cameraUI.GetComponent<Interface>();
        cm = camera.GetComponent<CameraMove>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && key.boolc)
        {
            BeginIneractiveScene();
        }

        if (Input.GetKeyDown(KeyCode.Q) && key.boolc)
        {
            EndInterativeScene();
        }
    }

    private void EndInterativeScene()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Player.inActiveState = true;
        _interface.HideInventory();
    }

    private void BeginIneractiveScene()
    {
        Cursor.lockState = CursorLockMode.Confined;
        cm.StartMove(CameraPosition.position);

        /*Transform aa = PointToLookAt;
        aa.position = PointToLookAt.position - CameraPosition.position + CameraPosition.position;
        Instantiate(PointToLookAt.gameObject, aa);*/


        cm.StartRotate(PointToLookAt.position - CameraPosition.position);
        cm.ReturnToDefaultPos(CameraPosition.position, PointToLookAt.position);
        Player.inActiveState = false;
        
        _interface.ActivateInventory();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            key.boolc = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            key.boolc = false;
        }
    }
}

