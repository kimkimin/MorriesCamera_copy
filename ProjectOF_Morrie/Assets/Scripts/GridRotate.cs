using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRotate : MonoBehaviour
{
    [Tooltip("그리드가 회전 각도")]
    public Vector3 setGridRotation;
    [Tooltip("그리드가 회전되는 zoom 값")]
    public float getGridZoom;
    [Tooltip("DragCameraMove.cs 에서 그리드 회전여부 확인용")]
    public bool b_isGridRotate = false;
    
    public GameObject GridForImage, GridForCam;
    public GameObject cameraActive;
    public Play_DragCameraZoom insZoom;
    public CameraMode insCamMode;

    /*
    public delegate void GridRotateDelegate();
    public static event GridRotateDelegate LayDown;
    public static event GridRotateDelegate StandUp;
    public static float gridSpeed;
    */
    void Update()
    {
        if (Camera.main.fieldOfView < getGridZoom)//zoom in
        {
            float SpeedClamp = Mathf.Clamp(Mathf.Abs(insZoom.FrameChangeForGridRot), 40, 450);
            //gridSpeed = SpeedClamp;
            //LayDown?.Invoke();
            GridForImage.transform.eulerAngles =
                Vector3.MoveTowards(GridForImage.transform.eulerAngles, setGridRotation, Time.deltaTime * SpeedClamp);

            gameObject.transform.eulerAngles = GridForImage.transform.eulerAngles;
            GridForCam.transform.eulerAngles = GridForImage.transform.eulerAngles;

            //카메라 ui활성화
            if (!b_isGridRotate)
            {
                cameraActive.SetActive(true);
                if (CameraMode.b_autoMode) insCamMode.AutoButton();
                else insCamMode.ManualButton();
                b_isGridRotate = true;
            }
        }
        else//zoom out
        {
            float SpeedClamp = Mathf.Clamp(Mathf.Abs(insZoom.FrameChangeForGridRot), 40, 450);
            //gridSpeed = SpeedClamp;
            //StandUp?.Invoke();
            GridForImage.transform.eulerAngles =
                Vector3.MoveTowards(GridForImage.transform.eulerAngles, Vector3.zero, Time.deltaTime * SpeedClamp);

            gameObject.transform.eulerAngles = GridForImage.transform.eulerAngles;
            GridForCam.transform.eulerAngles = GridForImage.transform.eulerAngles;

            if (b_isGridRotate)
            {
                cameraActive.SetActive(false);
                insCamMode.autoViewfinder.SetActive(false);
                b_isGridRotate = false;
            }
        }
        Camera.main.transform.position = transform.position;
    }
}
