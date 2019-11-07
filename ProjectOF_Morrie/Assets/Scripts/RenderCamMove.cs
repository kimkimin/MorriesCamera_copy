using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 정답일 경우 랜더카메라를 메인카메라 위치로 이동
/// </summary>
public class RenderCamMove : MonoBehaviour
{
    public void CorrectAnswerMove()
    {
        transform.position = Camera.main.transform.position;
        GetComponent<Camera>().fieldOfView = Camera.main.GetComponent<Camera>().fieldOfView;
    }
}
