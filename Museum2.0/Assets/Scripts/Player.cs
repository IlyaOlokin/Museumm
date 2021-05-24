using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController cc;
    public float speed = 10f;
    
    private Vector3 velocity;
    private bool isGrounded;
    public static bool inActiveState = true;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        if (inActiveState)
        {
            Move();
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 newPos = transform.right * x + transform.forward * z;
        cc.Move(speed * Time.deltaTime * newPos);
    }
}
