using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 모드에 따라 정답을 확인
/// </summary>
public class AnswerCheck : MonoBehaviour
{
    public RectTransform boxRT, viewRT; //boxRectTransform
    public float boxSizeMin, boxSizeMax;
    public AnswerGetList insAnswerList;
    public RenderViewActive insRenderView;

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
    /// Manu모드에서 드래그시 박스가 촬영가능 영역인지 표시
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
    /// Manu모드에서 드래그 종료시 정답영역을 확인하고 프린트
    /// </summary>
    public void CheckingAnswerDragEnd()
    {
        if (!b_isSizeFit) return;
        
        boxRT.gameObject.SetActive(false);
        insRenderView.ActiveRenderView();
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
    /// Auto모드에서 카메라버튼을 눌렀을때 정답영역을 확인하고 프린트
    /// </summary>
    public void CheckingAnswerCamButton()
    {
        insRenderView.ActiveRenderView();
        if (CheckingArea(viewRT))
        {
            print("Right");
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
}
