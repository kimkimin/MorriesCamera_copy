using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 정답 목록을 가져오고, 해당 목록의 위치값과 코너값 리스트를 return
/// </summary>
public class Play_AnswerGetList : MonoBehaviour
{
    public GameObject[] rightAnswer;
    public Vector3[] rightPos;

    // Start is called before the first frame update
    void Start()
    {
        rightPos = new Vector3[rightAnswer.Length];
        GetAnswerPosition();
    }

    /// <summary>
    /// rightAnswer의 위치정보 저장후 전달
    /// </summary>
    public Vector3[] GetAnswerPosition()
    {
        for (int i = 0; i < rightAnswer.Length; i++)
        {
            rightPos[i] = rightAnswer[i].GetComponent<Renderer>().bounds.center;
        }
        return rightPos;
    }

    /// <summary>
    /// 중점에서 (사이즈/4)만큼 +-해서 실제이미지보다 안쪽으로 위치한 코너값을 리턴
    /// return vector3[](각 코너의 리스트)
    /// </summary>
    /// <param name="spineObject"> 정답 혹은 오답 </param>
    public Vector3[] GetSizedeltaFromRender(GameObject spineObject)
    {
        Bounds spineBounds = spineObject.GetComponent<Renderer>().bounds;
        Vector3 spineSize = spineBounds.size / 4;//실제 이미지보다 더 작게하는 부분

        Vector3 minFromPoint = new Vector3(spineBounds.min.x + spineSize.x, spineBounds.min.y + spineSize.y, spineObject.GetComponent<Transform>().position.z);
        Vector3 maxFromPoint = new Vector3(spineBounds.max.x - spineSize.x, spineBounds.max.y - spineSize.y, spineObject.GetComponent<Transform>().position.z);

        Vector3 corner1 = new Vector3(minFromPoint.x, maxFromPoint.y, spineObject.GetComponent<Transform>().position.z);
        Vector3 corner4 = new Vector3(maxFromPoint.x, minFromPoint.y, spineObject.GetComponent<Transform>().position.z);

        Vector3[] spineCorner = { corner1, maxFromPoint, minFromPoint, corner4 };

        return spineCorner;
    }
}
