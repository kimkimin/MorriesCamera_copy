using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCameraMove : MonoBehaviour
{
    public float CamMoveSpeed;
    public float CamMoveClamp_ZoomOut;// = 6.5f;
    public float CamMoveClamp_ZoomOut_OnZoomed;// = 10.5f;

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

    
    public void OnTouchBegan_ToCameraMove()
    {
        if (!enabled) return;

        StartTouch = Link_touchCheck.touch.position;
        StartMouse = Input.mousePosition;

        StartTouch_world = Camera.main.ScreenToWorldPoint(StartTouch
            + Vector3.forward * -Camera.main.transform.position.z);
        //start좌표를 저장하고 월드좌표로 바꿔주는 타이밍도 중요!
    }
    public void OnTouchMoved_ToCameraMove()
    {if (!enabled) return;

        OnTouchMoved_ZoomOff();
    }


    /// <summary>
    /// 드래그&줌인 됐을때 실행되는 함수
    /// </summary>
    public void OnTouchMoved_ZoomOn()
    {
        Vector3 PreviousPos = Link_touchCheck.touch.position - Link_touchCheck.touch.deltaPosition;

        Vector3 CurrentGap = StartTouch - (Vector3)Link_touchCheck.touch.position;
        Vector3 PreviousGap = StartTouch - PreviousPos;

        float EachFrameMag = Mathf.Abs((PreviousGap.magnitude - CurrentGap.magnitude) * 0.1f);//0.02f
        //속도(지금은 0.02f가 젤 적절한데 씬마다 다른지 확인해야함)랑 방향 수정

        Vector3 EachFrameDiff = -(PreviousGap - CurrentGap).normalized * 0.1f * EachFrameMag;
        CamAnchor.transform.Translate(EachFrameDiff);

        CamAnchor.transform.localPosition = new Vector3(
            Mathf.Clamp(CamAnchor.transform.localPosition.x, -CamMoveClamp_ZoomOut_OnZoomed, CamMoveClamp_ZoomOut_OnZoomed),
            Mathf.Clamp(CamAnchor.transform.localPosition.y, -CamMoveClamp_ZoomOut_OnZoomed, CamMoveClamp_ZoomOut_OnZoomed),
            CamAnchor.transform.localPosition.z);

        Camera.main.transform.position = CamAnchor.transform.position;

    }

    /// <summary>
    /// 드래그&줌아웃 됐을때 실행되는 함수
    /// </summary>
    public void OnTouchMoved_ZoomOff()
    {
        Vector3 EndTouch_world = Camera.main.ScreenToWorldPoint((Vector3)Link_touchCheck.touch.position
            + Vector3.forward * -Camera.main.transform.position.z);

        Vector3 TouchGap_WorldTouch = EndTouch_world - StartTouch_world;
        CamAnchor.transform.localPosition -= TouchGap_WorldTouch;

        CamAnchor.transform.localPosition = new Vector3(
            Mathf.Clamp(CamAnchor.transform.localPosition.x, -CamMoveClamp_ZoomOut, CamMoveClamp_ZoomOut),
            Mathf.Clamp(CamAnchor.transform.localPosition.y, -CamMoveClamp_ZoomOut, CamMoveClamp_ZoomOut),
            CamAnchor.transform.localPosition.z);

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        CamAnchor.transform.localPosition = Vector3.MoveTowards(CamAnchor.transform.localPosition,
            new Vector3(CamAnchor.transform.localPosition.x, CamAnchor.transform.localPosition.y, 0), 0.02f);
        //z축 0으로 고정 (엄청 크게는 상관없는데 값변하는게 신경쓰여서 추가함)[0617]
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        Camera.main.transform.position = CamAnchor.transform.position;
    }
}
