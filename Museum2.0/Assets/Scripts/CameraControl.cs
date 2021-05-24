using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform player;
    private float xRot;
    private float yRot;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Player.inActiveState = false;
    }

    
    void Update()
    {
        MouseLook();
    }

    private void MouseLook()
    {
        if (Player.inActiveState)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 5 * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 5 * Time.deltaTime;

            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90f, 90f);


            transform.localRotation = Quaternion.Euler(xRot, 0, 0);
            player.Rotate(Vector3.up * mouseX);
        }
    }
}
