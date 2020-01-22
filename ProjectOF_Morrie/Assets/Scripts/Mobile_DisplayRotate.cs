using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 기기가 회전할때 보이는 비율 맞추기, 카메라 fov 맞추기
/// </summary>
public class Mobile_DisplayRotate : MonoBehaviour
{
    public float saveGridRot;
    public Vector2 saveBeforeDamping, saveAfterDamping;
    public int previousRatio;
    public Play_DragCameraZoom ins_zoom;
    public GridRotate ins_grid;
    Mobile_DisplayRotateUI ins_rotUi;

    // Start is called before the first frame update
    void Start()
    {
        ins_rotUi = GetComponent<Mobile_DisplayRotateUI>();
        previousRatio = (int)Camera.main.aspect;

        saveAfterDamping = ins_zoom.AfterDamping;
        saveBeforeDamping = ins_zoom.BeforeDamping;
        saveGridRot = ins_grid.getGridZoom;
    }

    // Update is called once per frame
    void Update()
    {
        CheckCameraOrientation();
    }

    void CheckCameraOrientation()
    {
        if (Screen.width > Screen.height)//Landscape
        {
            if (previousRatio != (int)Camera.main.aspect)
            {
                ResizingLandscapeZoomLimit();
                Camera.main.fieldOfView = ZoomClampFOV_Resize(Camera.main.fieldOfView);
                previousRatio = (int)Camera.main.aspect;
                ins_rotUi.SetUILandscape();
                print("RotateChange");
            }
        }
        else//Portrait
        {
            if (previousRatio != (int)Camera.main.aspect)
            {
                ResizingPortraitZoomLimit();
                Camera.main.fieldOfView = ZoomClampFOV_Resize(Camera.main.fieldOfView);
                previousRatio = (int)Camera.main.aspect;
                ins_rotUi.SetUIPortrait();
            }
        }
    }

    public void CheckCameraMode()
    {
        saveAfterDamping.x = ins_zoom.a_zoomInAfterDamping;
        saveBeforeDamping.x = ins_zoom.a_zoomInBeforeDamping;

        CheckCameraOrientation();
    }
    float ZoomClampFOV_Resize(float fromFOV)
    {
        float fov_h = fromFOV * Mathf.Deg2Rad;
        float cam_h = Mathf.Tan(fov_h * 0.5f) / Camera.main.aspect;
        float fov_v = Mathf.Atan(cam_h) * 2;
        float toFOV = fov_v * Mathf.Rad2Deg;

        return toFOV;
    }

    public void ResizingLandscapeZoomLimit()
    {
        ins_grid.getGridZoom = ZoomClampFOV_Resize(saveGridRot);

        ins_zoom.AfterDamping.x = ZoomClampFOV_Resize(saveAfterDamping.x);
        ins_zoom.AfterDamping.y = ZoomClampFOV_Resize(saveAfterDamping.y);

        ins_zoom.BeforeDamping.x = ZoomClampFOV_Resize(saveBeforeDamping.x);
        ins_zoom.BeforeDamping.y = ZoomClampFOV_Resize(saveBeforeDamping.y);
    }

    void ResizingPortraitZoomLimit()
    {
        ins_grid.getGridZoom = saveGridRot;

        ins_zoom.AfterDamping.x = saveAfterDamping.x;
        ins_zoom.AfterDamping.y = saveAfterDamping.y;

        ins_zoom.BeforeDamping.x = saveBeforeDamping.x;
        ins_zoom.BeforeDamping.y = saveBeforeDamping.y;
    }
}
