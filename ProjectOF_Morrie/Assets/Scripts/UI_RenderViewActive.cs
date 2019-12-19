using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 렌더뷰가 활성화 됐을때 터치를 방지, 
/// 렌더뷰 애니메이션 종료시 렌더뷰 비활성화
/// </summary>
public class UI_RenderViewActive : MonoBehaviour
{
    public Play_RenderCamMove insRenderCam;
    public UI_RenderViewMaskResetting insRenderMask;
    public PictureSave insPictureSave;
    public PictureLoad insPictureLoad;
    public UI_PhotoDup insPhotoDupl;
    bool photoStart = false;//최초사진저장체크

    private void OnEnable()
    {
        Play_DragCameraZoom.b_IsTouch2 = !Play_DragCameraZoom.b_IsTouch2;
        print(Play_DragCameraZoom.b_IsTouch2);
    }
    private void OnDisable()
    {
        Play_DragCameraZoom.b_IsTouch2 = !Play_DragCameraZoom.b_IsTouch2;
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
        if (!photoStart)
        {
            insPictureSave.SavePhoto();
            photoStart = true;
        }
        else
        {
            insPictureSave.SavePhoto();
            insPhotoDupl.DuplicatePrefab();
        }
        //애니메이션에서 사진저장을 실행함
        //여기서 프리팹생성및 해당포토에 로드하기
    }
}
