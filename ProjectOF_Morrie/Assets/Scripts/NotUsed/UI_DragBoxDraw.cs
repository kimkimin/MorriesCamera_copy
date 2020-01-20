using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

/// <summary>
/// 이거자체가 필요없는거 아닐까
/// </summary>
public class UI_DragBoxDraw : MonoBehaviour
{
    public RectTransform boxImage;
    public Canvas standardCanvas;
    public bool b_isDrawBox = false;
    public Play_AnswerCheck insAnswer;

    Vector3 cameraCenter;
    Vector3 startPos, endPos;

    private void OnEnable()
    {
        Link_touchCheck.OnTouchBegan += this.DragBoxStart;
        Link_touchCheck.OnTouchEnded += this.DragBoxEnd;
    }
    private void OnDisable()
    {
        Link_touchCheck.OnTouchBegan -= this.DragBoxStart;
        Link_touchCheck.OnTouchEnded -= this.DragBoxEnd;
    }

    void Update()
    {
        cameraCenter = Camera.main.WorldToScreenPoint(standardCanvas.transform.position);

        if (b_isDrawBox)
            DragBoxOnDraging();
    }

    /// <summary>
    /// 드래그 시작, 화면 기준 터치좌표 저장
    /// </summary>
    public void DragBoxStart()
    {   if (!enabled) return;
        //if (!CameraButton.b_manualCameraActive) return;

        boxImage.gameObject.SetActive(true);

        Vector3 TempMouse;
        TempMouse.x = Mathf.Clamp(Link_touchCheck.touch.position.x, cameraCenter.x - Screen.width/2, cameraCenter.x + Screen.width / 2);
        TempMouse.y = Mathf.Clamp(Link_touchCheck.touch.position.y, cameraCenter.y - Screen.height/2 , cameraCenter.y + Screen.height / 2);
        TempMouse.z = 0;

        Vector2 tempPosVector2;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
                                    standardCanvas.transform as RectTransform, TempMouse,
                                    standardCanvas.worldCamera, out tempPosVector2);

        startPos = tempPosVector2;
        b_isDrawBox = true;
    }

    /// <summary>
    /// 드래그, 화면 기준 터치좌표 저장, 드래그 박스 위치 설정, 드래그 박스 사이즈 설정
    /// </summary>
    public void DragBoxOnDraging()
    {   if (!enabled) return;
        //if (!CameraButton.b_manualCameraActive) return;

        Vector3 TempMouse;
        TempMouse.x = Mathf.Clamp(Link_touchCheck.touch.position.x, cameraCenter.x - Screen.width / 2, cameraCenter.x + Screen.width / 2);
        TempMouse.y = Mathf.Clamp(Link_touchCheck.touch.position.y, cameraCenter.y - Screen.height / 2, cameraCenter.y + Screen.height / 2);
        TempMouse.z = 0;

        Vector2 tempPosVector2;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
                                    standardCanvas.transform as RectTransform, TempMouse,
                                    standardCanvas.worldCamera, out tempPosVector2);
        endPos = tempPosVector2;
        boxImage.position = standardCanvas.transform.TransformPoint((startPos + GetNewRatioEndPoint(startPos, endPos)) / 2);
        //드래그 박스의 위치는 월드기준으로 드래그 첫점과 끝점사이의 중점(드래그 중심)

        float sizeX = Mathf.Abs(startPos.x - endPos.x);
        float sizeY = sizeX;
        boxImage.sizeDelta = new Vector2(sizeX, sizeY);
        //드래그 박스의 사이즈x,y는 드래그 된 영역만큼의 사이즈

    }

    /// <summary>
    /// 드래그 종료, 초기화 
    /// </summary>
    public void DragBoxEnd()
    {//if(!insAnswer.b_isSizeFit) boxImage.sizeDelta = Vector2.zero;//수정필요
    
        if (!enabled) return;
        //if (!CameraButton.b_manualCameraActive) return;
        
        if (b_isDrawBox)//버튼클릭과 동시에 드래그실행됨을 방지
        {
            boxImage.gameObject.SetActive(false);
            b_isDrawBox = false;
        }
    }

    
    /// <summary>
    /// 드래그 방향과 상관없이 계산가능한 끝점 반환
    /// </summary>
    Vector3 GetNewRatioEndPoint(Vector3 start, Vector3 end)
    {
        Vector3 newEnd = end;
        float width_ = Mathf.Abs(end.x - start.x);
        float height_ = Mathf.Abs(end.y - start.y);
        float differenceY = height_ - width_;

        if (start.y > end.y) newEnd.y += differenceY;
        else newEnd.y -= differenceY;

        return newEnd;
    }
}
