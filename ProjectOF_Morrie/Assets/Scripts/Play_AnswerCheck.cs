using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 모드에 따라 정답을 확인
/// </summary>
public class Play_AnswerCheck : MonoBehaviour
{
    public RectTransform boxRT, viewRT; //boxRectTransform
    //public float boxSizeMin, boxSizeMax;
    public Play_AnswerGetList insAnswerList;
    public UI_RenderViewActive insRenderView;
    public GameObject Exit;
    //public bool b_isSizeFit = false;



    /// <summary>
    /// Auto모드에서 카메라버튼을 눌렀을때 정답영역을 확인하고 프린트
    /// </summary>
    public void CheckingAnswerCamButton()
    {
        insRenderView.ActiveRenderView();
        if (CheckingArea(viewRT))
        {
            print("Right");
            Exit.SetActive(true);
        }
        else
        {
            print("Wrong");
        }
    }
    
    /// <summary>
    /// CheckRT 영역안에 정답이 있는지 확인
    /// </summary>
    public bool CheckingArea(RectTransform CheckRT)//CheckRectTransform
    {if (insAnswerList.rightPos.Length <= 0) return false;//정답설정(위치설정)이 안되어있을경우 정답아님

        for (int i = 0; i < insAnswerList.rightAnswer.Length; i++)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(CheckRT, insAnswerList.GetAnswerPosition()[i]))//position 확인
            {
                for (int j = 0; j < 4; j++)
                {
                    if (!RectTransformUtility.RectangleContainsScreenPoint(CheckRT, insAnswerList.GetSizedeltaFromRender(insAnswerList.rightAnswer[i])[j]))//corner 확인
                        return false;
                }
                return true;
            }
        }
        return false;
    }
}
