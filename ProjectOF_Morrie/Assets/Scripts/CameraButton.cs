using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 카메라 버튼 클릭, 자동수동을 구분하여 작동
/// </summary>
public class CameraButton : MonoBehaviour
{
    public GameObject dragBoxDrawActive;
    public GameObject manualViewFinder;
    public Play_AnswerCheck insAnswerCheck;
    public static bool b_manualCameraActive = false;
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
        if (CameraMode.b_autoMode) AutoCamButton();
        else ManualCamButton();
    }

    void AutoCamButton()
    {
        insAnswerCheck.CheckingAnswerCamButton();
        print("Save Photo");
    }
    public void ManualCamButton()
    {
        if (b_manualCameraActive)
        {
            manualViewFinder.SetActive(false);
            dragBoxDrawActive.SetActive(false);
            b_manualCameraActive = false;
        }
        else
        {
            manualViewFinder.SetActive(true);
            dragBoxDrawActive.SetActive(true);
            b_manualCameraActive = true;
        }
        print("Save Photo");
    }
}
