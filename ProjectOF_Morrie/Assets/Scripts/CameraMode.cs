using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 카메라 모드를 전환
/// </summary>
public class CameraMode : MonoBehaviour
{
    public static bool b_autoMode = true;
    public static bool b_manualMode = false;

    public GameObject autoViewfinder, maueViewfinder;
    public CameraButton camButton;

    public void AutoButton()
    {
        b_autoMode = true;
        b_manualMode = false;
        AutoModeSetting();
    }
    public void ManualButton()
    {
        b_autoMode = false;
        b_manualMode = true;
        ManualModeSetting();
    }

    public void AutoModeSetting()
    {if (b_manualMode) return;

        autoViewfinder.SetActive(true);
        camButton.OnCamButton();
        //오토뷰 활성
        //카메라버튼에서 b_manualCameraActive false로 두고 ManualCamButton() 실행
    }
    public void ManualModeSetting()
    {if (b_autoMode) return;

        autoViewfinder.SetActive(false);
        maueViewfinder.SetActive(false);
        //오토뷰 비활성
        //매뉴얼뷰 비활성
    }
}
