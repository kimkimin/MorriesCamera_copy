using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerCheck : MonoBehaviour
{
    public RectTransform boxImage;
    public Vector2 boxSizeMin, boxSizeMax;
    public AnswerGetList insAnswerList;

    bool b_isSizeFit = false;

    public void SizeCheckWhileDraging()
    {
        if(boxImage.sizeDelta.x > boxSizeMin.x && boxImage.sizeDelta.y >= boxSizeMin.y)
        {
            if(boxImage.sizeDelta.x < boxSizeMax.x && boxImage.sizeDelta.y < boxSizeMax.y)
            {
                b_isSizeFit = true;
                boxImage.gameObject.GetComponent<Image>().color = Color.green * new Color(1, 1, 1, 0.5f);
            }
            else
            {
                b_isSizeFit = false;
                boxImage.gameObject.GetComponent<Image>().color = Color.grey * new Color(1, 1, 1, 0.5f); ;
            }
        }
    }

    public void FigureOutDragEnded()
    {   if (!enabled) return;
        if (!b_isSizeFit) return;

        
        //if
    }

    /**/
    /// <summary>
    /// 드래그와 찾은이미지 비교
    /// 손이 떨어졌을때 드래그박스가 이미지범위에서 벗어났는지를 확인
    /// 1. 정가운데 위치 포인트가 포함되는지 확인
    /// 2. true일경우 오답을 확인해서 
    /// </summary>
    public bool DragHideCompare(RectTransform CheckRecttransform)//
    {
        //정답 이미지의 모든 코너가 박스안에 들어왔을때로 수정하기
        //0. 위치포인트 들어오는지 확인
        //1. 정답 코너 리스트비교 > 위치비교, 각 코너비교
        //2. 오답 코너 리스트비교 > 위치비교, 각 코너비교
        //3. true false 체크하기
        //
        //으ㄸㄷ 


        for (int i = 0; i < insAnswerList.rightAnswer.Length; i++)
        {

            if (RectTransformUtility.RectangleContainsScreenPoint(CheckRecttransform, insAnswerList.GetAnswerPosition()[i]))//position 확인
            {
                for (int j = 0; j < 4; j++)
                {
                    if (!RectTransformUtility.RectangleContainsScreenPoint(CheckRecttransform, insAnswerList.GetSizedeltaFromRender(insAnswerList.rightAnswer[i])[j]))//corner 확인
                        return false;
                }
                return true;
            }
        }
        return false;
    }
}
