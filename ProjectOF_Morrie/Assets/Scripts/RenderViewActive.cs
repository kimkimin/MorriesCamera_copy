using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 렌더뷰가 활성화 됐을때 터치를 방지, 
/// 렌더뷰 애니메이션 종료시 렌더뷰 비활성화
/// </summary>
public class RenderViewActive : MonoBehaviour
{
    public RenderCamMove insRenderCam;
    public RenderViewMaskResetting insRenderMask;
    public PictureSave insPictureSave;
    public PictureLoad insPictureLoad;

    private void OnEnable()
    {
        DragCameraZoom.b_IsTouch2 = !DragCameraZoom.b_IsTouch2;
        print(DragCameraZoom.b_IsTouch2);
    }
    private void OnDisable()
    {
        DragCameraZoom.b_IsTouch2 = !DragCameraZoom.b_IsTouch2;
        //print(DragCameraZoom.b_IsTouch2);
    }

    /// <summary>
    /// 애님 종료시 랜더뷰 비활성화 실행
    /// </summary>
    public void DeactivateRenderView()
    {
        insPictureLoad.LoadA_Picture();//임시
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 랜더뷰 활성화
    /// </summary>
    public void ActiveRenderView()
    {
        gameObject.SetActive(true);
        insRenderMask.MaskResizing();
        insRenderCam.CorrectAnswerMove();
    }

    /// <summary>
    /// 애님 중간에 랜더뷰 팝업되었을때 사진저장 실행
    /// </summary>
    public void SavePhotoFromPictureSave()
    {
        insPictureSave.SavePhoto();
    }
}
