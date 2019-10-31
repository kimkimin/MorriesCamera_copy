using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Link_touchCheck : MonoBehaviour
{
    public static Touch touch;
    public delegate void TouchDelegate();

    public static event TouchDelegate OnTouchBegan;
    public static event TouchDelegate OnTouchMoved;
    public static event TouchDelegate OnTouchEnded;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && !DragCameraZoom.b_IsTouch2)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                OnTouchBegan?.Invoke();
            if (touch.phase == TouchPhase.Moved)
                OnTouchMoved?.Invoke();
            else if (touch.phase == TouchPhase.Ended)
                OnTouchEnded?.Invoke();
        }
    }
}
