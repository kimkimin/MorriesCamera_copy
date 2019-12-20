using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 카메라 버튼 클릭, 자동수동을 구분하여 작동
/// </summary>
public class CameraButton : MonoBehaviour
{
    public GameObject dragBoxDrawActive;
    public GameObject manualViewFinder;
    public static bool b_manualCameraActive = false;
    public Play_AnswerCheck insAnswerCheck;

    public void OnCamButton()
    {
#if UNITY_IOS
        binding.SuccessHaptic();
#endif
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
