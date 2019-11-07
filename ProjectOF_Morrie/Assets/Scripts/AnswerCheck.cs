using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manual모드에서 정답을 확인
/// </summary>
public class AnswerCheck : MonoBehaviour
{
    public RectTransform boxRT; //boxRectTransform
    public float boxSizeMin, boxSizeMax;
    //public GameObject renderView;
    public AnswerGetList insAnswerList;
    public RenderViewActive insRenderView;
    //public RenderCamMove insRenderCam;
    //public RenderViewMaskResetting insRenderMask;

    public bool b_isSizeFit = false;

    private void OnEnable()
    {
        Link_touchCheck.OnTouchMoved += this.CheckingSizeDragMove;
        Link_touchCheck.OnTouchEnded += this.CheckingAnswerDragEnd;
    }
    private void OnDisable()
    {
        Link_touchCheck.OnTouchMoved -= this.CheckingSizeDragMove;
        Link_touchCheck.OnTouchEnded -= this.CheckingAnswerDragEnd;
    }

    /// <summary>
    /// 드래그시 박스가 촬영가능 영역인지 표시
    /// </summary>
    public void CheckingSizeDragMove()
    {if (!gameObject.activeSelf) return;

        if(boxRT.sizeDelta.x > boxSizeMin)
        {
            if(boxRT.sizeDelta.x < boxSizeMax)
            {
                b_isSizeFit = true;
                boxRT.gameObject.GetComponent<Image>().color = Color.green * new Color(1, 1, 1, 0.5f);
            }
            else
            {
                b_isSizeFit = false;
                boxRT.gameObject.GetComponent<Image>().color = Color.grey * new Color(1, 1, 1, 0.5f); ;
            }
        }
        else
        {
            b_isSizeFit = false;
            boxRT.gameObject.GetComponent<Image>().color = Color.grey * new Color(1, 1, 1, 0.5f); ;
        }
    }

    /// <summary>
    /// 드래그 종료시 정답영역을 확인하고 프린트
    /// </summary>
    public void CheckingAnswerDragEnd()
    {   if (!enabled) return;
        if (!b_isSizeFit) return;

        boxRT.gameObject.SetActive(false);
        insRenderView.ActiveRenderView();
        //renderView.SetActive(true);
        //insRenderMask.MaskResizing();
        //insRenderCam.CorrectAnswerMove();
        if (CheckingArea(boxRT))
        {
            print("Right");
        }
        else
        {
            print("Wrong");
        }

        b_isSizeFit = false;//초기화

    }
    
    /// <summary>
    /// 드래그 영역안에 정답이 있는지 확인
    /// </summary>
    public bool CheckingArea(RectTransform CheckRT)//CheckRectTransform
    {
        for (int i = 0; i < insAnswerList.rightAnswer.Length; i++)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(CheckRT, insAnswerList.GetAnswerPosition()[i]))//position 확인
            {
                print("위치통과");
                for (int j = 0; j < 4; j++)
                {
                    if (!RectTransformUtility.RectangleContainsScreenPoint(CheckRT, insAnswerList.GetSizedeltaFromRender(insAnswerList.rightAnswer[i])[j]))//corner 확인
                        return false;
                }
                return true;
            }
            print(insAnswerList.GetAnswerPosition()[i] + ", in " + CheckRT.transform.position);
        }
        return false;
    }
    //오답 확인할 필요없음 
}
