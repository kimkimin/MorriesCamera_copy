using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 카메라 버튼 클릭, 자동수동을 구분하여 작동
/// </summary>
public class CameraButton : MonoBehaviour
{
    //public GameObject dragBoxDrawActive;
    public Play_AnswerCheck insAnswerCheck;
    public static int rollNum = 6;

    private void Start()
    {
        gameObject.GetComponentInChildren<Text>().text = rollNum.ToString();
    }
    public void OnCamButton()
    {
        if (rollNum <= 0) return;
#if UNITY_IOS
        //binding.SuccessHaptic();
#endif
        rollNum--;
        gameObject.GetComponentInChildren<Text>().text = rollNum.ToString();
        insAnswerCheck.CheckingAnswerCamButton();
    }
}