using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class DragBoxDraw : MonoBehaviour
{
    public RectTransform boxImage;
    public Canvas standardCanvas;
    public bool b_isDrawBox = false;
    public AnswerCheck insAnswer;

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

    public void DragBoxStart()
    {   if (!enabled) return;
        if (!CameraButton.b_manualCameraActive) return;

        boxImage.gameObject.SetActive(true);

        Vector3 TempMouse;
        TempMouse.x = Mathf.Clamp(Link_touchCheck.touch.position.x, cameraCenter.x - 530, cameraCenter.x + 540);//캔버스내에서 벗어나지 못하게막음
        TempMouse.y = Mathf.Clamp(Link_touchCheck.touch.position.y, cameraCenter.y - 959, cameraCenter.y + 960);
        TempMouse.z = 0;

        Vector2 tempPosVector2;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
                                    standardCanvas.transform as RectTransform, TempMouse,
                                    standardCanvas.worldCamera, out tempPosVector2);

        startPos = tempPosVector2;
        b_isDrawBox = true;
    }

    public void DragBoxOnDraging()
    {   if (!enabled) return;
        if (!CameraButton.b_manualCameraActive) return;

        Vector3 TempMouse;
        TempMouse.x = Mathf.Clamp(Link_touchCheck.touch.position.x, cameraCenter.x - 530, cameraCenter.x + 540);
        TempMouse.y = Mathf.Clamp(Link_touchCheck.touch.position.y, cameraCenter.y - 959, cameraCenter.y + 960);
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

    public void DragBoxEnd()
    {if(!insAnswer.b_isSizeFit) boxImage.sizeDelta = Vector2.zero;


        if (!enabled) return;
        if (!CameraButton.b_manualCameraActive) return;

        //드래그 박스가 끝나고
        if (b_isDrawBox)//버튼클릭과 동시에 드래그실행됨을 방지
        {
            boxImage.gameObject.SetActive(false);
            b_isDrawBox = false;
        }
    }


    //드래그 방향과 상관없이 계산가능한 끝점
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
