using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mobile_DisplayRotateUI : MonoBehaviour
{
    public CanvasScaler MainCanvas;
    public RectTransform[] rotate90;
    public RectTransform[] rotateMinus90;// == 0, 네이밍 다시해야함
    public RectTransform[] scrolView;

    private void Start()
    {
        if (Screen.width > Screen.height) SetUILandscape();
    }

    public void SetUILandscape()
    {
        MainCanvas.referenceResolution = new Vector2(1920, 1080);

        for (int i = 0; i < rotate90.Length; i++)
        {
            if(i == 0)//camera active rePositioning
            {
                rotate90[i].anchorMax = new Vector2(0.5f, 0.5f);
                rotate90[i].anchorMin = new Vector2(0.5f, 0.5f);
                rotate90[i].anchoredPosition = Vector2.zero;
            }
            Vector3 tempRot = rotate90[i].eulerAngles;
            rotate90[i].eulerAngles = new Vector3(tempRot.x, tempRot.y, 90);
        }

        for (int i = 0; i < rotateMinus90.Length; i++)
        {
            //print("전" + rotateMinus90[i].eulerAngles);
            Vector3 tempRot = rotateMinus90[i].eulerAngles;
            rotateMinus90[i].eulerAngles = new Vector3(tempRot.x, tempRot.y, 0);
            //print("후" + rotateMinus90[i].eulerAngles);
        }

        for (int i = 0; i < scrolView.Length; i++)
        {
            Vector2 tempSize = scrolView[i].sizeDelta;
            scrolView[i].sizeDelta = new Vector2(tempSize.y, tempSize.x);
        }
    }

    public void SetUIPortrait()
    {
        MainCanvas.referenceResolution = new Vector2(1080, 1920);

        for (int i = 0; i < rotate90.Length; i++)
        {
            if (i == 0)//camera active rePositioning
            {
                rotate90[i].anchorMax = new Vector2(0.5f, 0f);
                rotate90[i].anchorMin = new Vector2(0.5f, 0f);
                rotate90[i].anchoredPosition = new Vector2(0, 960);
            }
            Vector3 tempRot = rotate90[i].eulerAngles;
            rotate90[i].eulerAngles = new Vector3(tempRot.x, tempRot.y, 0);
        }

        for (int i = 0; i < rotateMinus90.Length; i++)
        {
            Vector3 tempRot = rotateMinus90[i].eulerAngles;
            rotateMinus90[i].eulerAngles = new Vector3(tempRot.x, tempRot.y, 0);
        }

        for (int i = 0; i < scrolView.Length; i++)
        {
            Vector2 tempSize = scrolView[i].sizeDelta;
            scrolView[i].sizeDelta = new Vector2(tempSize.y, tempSize.x);
        }
    }
}