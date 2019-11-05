using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 카메라 줌
/// </summary>
public class DragCameraZoom : MonoBehaviour
{
    public float a_zoomInBeforeDamping, a_zoomInAfterDamping;
    public float ma_zoomInBeforeDamping, ma_zoomInAfterDamping;
    public float zoomOutBeforeDamping, zoomOutAfterDamping;

    public Vector2 BeforeDamping, AfterDamping;
    public Camera cam;

    [Tooltip("BOOL, 줌이 끝날때까지 drag move가(touchcount == 1) 실행하는것을 방지")]
    public static bool b_IsTouch2 = false;
    [Tooltip("FLOAT, grid 축회전이랑 줌속도 맞춰줄 드래그 변화량")]
    public float FrameChangeForGridRot;

    private void Awake()
    {
        BeforeDamping = new Vector2(a_zoomInBeforeDamping, zoomOutBeforeDamping);
        AfterDamping = new Vector2(a_zoomInAfterDamping, zoomOutAfterDamping);
    }

    void Update()
    {
        if (Input.touchCount == 2)
            ZoomStart();
        else if (Input.touchCount == 0 && b_IsTouch2)
            ZoomEnd();
    }

    /// <summary>
    /// 두손가락이 들어와서 드래그할때,
    /// 두손가락으로 드래그하는 양으로 줌한다
    /// </summary>
    void ZoomStart()
    {   if (CameraButton.b_manualCameraActive) return;
        if (!enabled) return;

        b_IsTouch2 = true;
        Touch touch0 = Input.GetTouch(0);
        Touch touch1 = Input.GetTouch(1);

        Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
        Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

        float prevMag = (touch0PrevPos - touch1PrevPos).magnitude;
        float currMag = (touch0.position - touch1.position).magnitude;

        float everyFrameChange = prevMag - currMag;
        FrameChangeForGridRot = everyFrameChange;//0612

        if (cam.orthographic)
        {
            cam.orthographicSize += everyFrameChange * 0.1f;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, BeforeDamping.x, BeforeDamping.y);
        }
        else
        {
            cam.fieldOfView += everyFrameChange * 0.1f;
            cam.fieldOfView = Mathf.Max(cam.fieldOfView, BeforeDamping.x);
            cam.fieldOfView = Mathf.Min(cam.fieldOfView, BeforeDamping.y);
        }
    }

    /// <summary>
    /// 드래그가 끝나고 화면이 지정범위를 벗어날경우 화면을 댐핑함
    /// </summary>
    void ZoomEnd()
    {   if (CameraButton.b_manualCameraActive) return;
        if (!enabled) return;

        b_IsTouch2 = false;
        if (cam.orthographic)
        {
            if (cam.orthographicSize < AfterDamping.x)
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, AfterDamping.x, 0.1f);
            else if (cam.orthographicSize > AfterDamping.y)
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, AfterDamping.y, 0.1f);
        }
        else
        {
            if (cam.fieldOfView < AfterDamping.x)
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, AfterDamping.x, 0.1f);
            else if (cam.fieldOfView > AfterDamping.y)
                cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, AfterDamping.y, 0.1f);
        }
    }
}
