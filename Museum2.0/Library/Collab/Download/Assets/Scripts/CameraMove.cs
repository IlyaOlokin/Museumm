using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private GameObject player;
    public Transform defaultPos;
    public Transform defaultRotationTarget;
    public bool isMoving;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 pointToLookAt;
    public float progress;
    public float step;
    public float rotateSpeed;
    public float time;

    void Start()
    {
        player = transform.parent.gameObject;
        time = 1 / (step * 50);
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Move();
            Rotate(pointToLookAt);
            if (Vector3.Distance(transform.position, endPos) < 0.01f)
            {
                isMoving = false;
            }
        }
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(startPos, endPos, progress);
        progress += step;
    }

    public void ReturnToDefaultPos(Vector3 pos, Vector3 rot)
    { 
        player.transform.position = new Vector3(pos.x, player.transform.position.y, pos.z);
        player.transform.LookAt(new Vector3(rot.x, player.transform.position.y, rot.z));
        StartMove(defaultPos.position);
        
    }

    public void ReturnToDefaultRotation()
    {
        StartRotate(defaultRotationTarget.position - defaultPos.position);
    }

    public void StartMove( Vector3 endPos)
    {
        progress = 0;
        isMoving = true;
        startPos = transform.position;
        this.endPos = endPos;
        
    }

    public void StartRotate(Vector3 target)
    {
        pointToLookAt = target;
        rotateSpeed = Vector3.Angle(transform.eulerAngles, target - transform.position) / time;
    }

    private void Rotate(Vector3 target)
    {
        Vector3 direction = target - transform.position;
        Quaternion rotate = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotate, rotateSpeed * Time.deltaTime);
    }

    public void ReturnPlayerControl()
    {
        StopAllCoroutines();
        StartCoroutine(ReturnControl());
    }

    IEnumerator ReturnControl()
    {
        yield return new WaitForSeconds(time);
        Player.ControlAvailable = true;
    }
}
