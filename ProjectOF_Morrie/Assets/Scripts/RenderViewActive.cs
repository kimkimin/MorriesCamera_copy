using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 렌더뷰가 활성화 됐을때 터치를 방지, 
/// 렌더뷰 애니메이션 종료시 렌더뷰 비활성화
/// </summary>
public class RenderViewActive : MonoBehaviour
{
    private void OnEnable()
    {
        DragCameraZoom.b_IsTouch2 = !DragCameraZoom.b_IsTouch2;
        print(DragCameraZoom.b_IsTouch2);
    }
    private void OnDisable()
    {
        DragCameraZoom.b_IsTouch2 = !DragCameraZoom.b_IsTouch2;
        print(DragCameraZoom.b_IsTouch2);
    }

    public void DeactivateRenderView()
    {
        gameObject.SetActive(false);
    }
}
