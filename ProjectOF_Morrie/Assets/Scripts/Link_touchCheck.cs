using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

/// <summary>
/// 터치 인풋을 검사
/// </summary>
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
        if (Input.touchCount == 1 && !Play_DragCameraZoom.b_IsTouch2)
        {
            touch = Input.GetTouch(0);
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId) == true) return;

            if (touch.phase == TouchPhase.Began)
                OnTouchBegan?.Invoke();
            if (touch.phase == TouchPhase.Moved)
                OnTouchMoved?.Invoke();
            else if (touch.phase == TouchPhase.Ended)
                OnTouchEnded?.Invoke();
        }
    }
}
