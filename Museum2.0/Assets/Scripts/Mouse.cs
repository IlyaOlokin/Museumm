using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public static GameObject DraggedItem;
    public GameObject d;

    public void Update()
    {
        d = DraggedItem;
    }
}
