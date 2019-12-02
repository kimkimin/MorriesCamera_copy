using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 카메라 이동
/// </summary>
public class Play_DragCameraMove : MonoBehaviour
{
    public float CamMoveSpeed;
    public float CamMoveClamp_ZoomOut;
    public float CamMoveClamp_ZoomOut_OnZoomed;

    GameObject CamAnchor;
    Vector3 StartTouch, StartMouse;
    Vector3 StartTouch_world;

    private void OnEnable()
    {
        Link_touchCheck.OnTouchBegan += this.OnTouchBegan_ToCameraMove;
        Link_touchCheck.OnTouchMoved += this.OnTouchMoved_ToCameraMove;
    }
    private void OnDisable()
    {
        Link_touchCheck.OnTouchBegan -= this.OnTouchBegan_ToCameraMove;
        Link_touchCheck.OnTouchMoved -= this.OnTouchMoved_ToCameraMove;
    }
    void Start()
    {
        CamAnchor = gameObject;
    }
    
    /// <summary>
    /// 터치 시작
    /// </summary>
    public void OnTouchBegan_ToCameraMove()
    {   if (!enabled) return;
        if (CameraButton.b_manualCameraActive) return;

        StartTouch = Link_touchCheck.touch.position;
        StartMouse = Input.mousePosition;

        StartTouch_world = Camera.main.ScreenToWorldPoint(
            StartTouch + Vector3.forward * -Camera.main.transform.position.z);
    }

    /// <summary>
    /// 터치중
    /// </summary>
    public void OnTouchMoved_ToCameraMove()
    {   if (!enabled) return;
        if (CameraButton.b_manualCameraActive) return;

        if (GetComponent<GridRotate>().b_isGridRotate) OnTouchMoved_ZoomOn();
        else OnTouchMoved_ZoomOff();
    }


    /// <summary>
    /// 드래그&줌인 됐을때 실행되는 함수
    /// </summary>
    public void OnTouchMoved_ZoomOn()
    {
        Vector3 PreviousPos = Link_touchCheck.touch.position - Link_touchCheck.touch.deltaPosition;

        Vector3 CurrentGap = StartTouch - (Vector3)Link_touchCheck.touch.position;
        Vector3 PreviousGap = StartTouch - PreviousPos;

        float EachFrameMag = Mathf.Abs((PreviousGap.magnitude - CurrentGap.magnitude) * 10f);//그래서 쓰리디일때는 갭을계산해서 이동하구

        Vector3 EachFrameDiff = -(PreviousGap - CurrentGap).normalized * 0.1f * EachFrameMag;
        CamAnchor.transform.Translate(EachFrameDiff);

        CamAnchor.transform.localPosition = new Vector3(
            Mathf.Clamp(CamAnchor.transform.localPosition.x, -CamMoveClamp_ZoomOut_OnZoomed, CamMoveClamp_ZoomOut_OnZoomed),
            Mathf.Clamp(CamAnchor.transform.localPosition.y, -CamMoveClamp_ZoomOut_OnZoomed, CamMoveClamp_ZoomOut_OnZoomed),
            CamAnchor.transform.localPosition.z);
    }

    /// <summary>
    /// 드래그&줌아웃 됐을때 실행되는 함수
    /// </summary>
    public void OnTouchMoved_ZoomOff()
    {
        Vector3 EndTouch_world = Camera.main.ScreenToWorldPoint((Vector3)Link_touchCheck.touch.position
            + Vector3.forward * -Camera.main.transform.position.z);

        Vector3 TouchGap_WorldTouch = EndTouch_world - StartTouch_world;//투디일때는 걍합니다.
        CamAnchor.transform.localPosition -= TouchGap_WorldTouch;

        CamAnchor.transform.localPosition = new Vector3(
            Mathf.Clamp(CamAnchor.transform.localPosition.x, -CamMoveClamp_ZoomOut, CamMoveClamp_ZoomOut),
            Mathf.Clamp(CamAnchor.transform.localPosition.y, -CamMoveClamp_ZoomOut, CamMoveClamp_ZoomOut),
            CamAnchor.transform.localPosition.z);
    }
}
