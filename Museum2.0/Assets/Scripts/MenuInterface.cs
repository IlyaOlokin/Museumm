using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInterface : MonoBehaviour
{
    public GameObject camera;
    private CameraMove cm;

    public Transform PositionMainMenu;
    public Transform PointToLookAtInMainMenu;
    
    public Transform PositionSettingsMenu;
    public Transform PointToLookAtInSettingsMenu;
    
    void Start()
    {
        camera.transform.position = PositionMainMenu.position;
        camera.transform.LookAt(PointToLookAtInMainMenu);
        
        cm = camera.GetComponent<CameraMove>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartGame();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            MoveToSettings();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            MoveToMainMenu();
        }
    }

    public void MoveToSettings()
    {
        cm.StartMove(PositionSettingsMenu.position);
        cm.StartRotate(PointToLookAtInSettingsMenu.position - PositionSettingsMenu.position);
    }
    
    public void MoveToMainMenu()
    {
        cm.StartMove(PositionMainMenu.position);
        cm.StartRotate(PointToLookAtInMainMenu.position - PositionMainMenu.position);
    }

    public void StartGame()
    {
        var cameraPos = new Vector3(cm.player.transform.position.x , camera.transform.position.y, cm.player.transform.position.z);
        
        cm.StartMove(cameraPos);
        cm.StartRotate(cm.defaultRotationTarget.position - cameraPos);
        cm.ReturnPlayerControl();
        Cursor.lockState = CursorLockMode.Locked;
    }
}
