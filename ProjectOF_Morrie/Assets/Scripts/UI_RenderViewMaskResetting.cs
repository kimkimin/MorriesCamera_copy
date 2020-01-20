using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 랜더뷰 세팅
/// </summary>
public class UI_RenderViewMaskResetting : MonoBehaviour
{
    public RectTransform boxRT, viewFinderRT;
    public Canvas tempCanvas;

    /// <summary>
    /// 렌더뷰의 마스크 사이즈를 찍을 영역에 맞추기
    /// </summary>
    public void MaskResizing()
    {
        //자동 : 1000*1000, 수동 : 드래그박스사이즈
        //여기에 600으로 만드는 계산넣어서 스케일값으로 대입하기
        GetComponent<RectTransform>().sizeDelta = viewFinderRT.sizeDelta;
        MaskReplacing_Auto();
        /*if (CameraMode.b_autoMode)//auto
        {
        }
        
        else//manual
        {
            GetComponent<RectTransform>().sizeDelta = boxRT.sizeDelta;
            MaskReplacing_Manual();
        }*/
        gameObject.GetComponent<RectTransform>().localScale = MaskRescaling(Vector3.one);
    }

    /// <summary>
    /// 수동모드일때 렌더뷰의 로드이미지가 드래그된영역위치에 맞춰서 이동
    /// </summary>
    public void MaskReplacing_Manual()
    {
        RectTransform FirstChild = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        FirstChild.localPosition = new Vector3(-boxRT.localPosition.x, -boxRT.localPosition.y, boxRT.localPosition.z);
    }
    
    /// <summary>
    /// 자동모드일때 렌더뷰의 로드이미지가 초기화됨
    /// </summary>
    public void MaskReplacing_Auto()
    {
        RectTransform FirstChild = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        FirstChild.localPosition = Vector3.zero;
    }

    /// <summary>
    /// 렌더뷰의 마스크를 고정된 사이즈(600)로 다시 스케일링
    /// </summary>
    Vector3 MaskRescaling(Vector3 maskScale)//auto manual all
    {
        float currentWidth = GetComponent<RectTransform>().sizeDelta.x;
        float targetWidth = 600;

        float multiplyScale = targetWidth / currentWidth;
        return maskScale * multiplyScale;
    }
}
