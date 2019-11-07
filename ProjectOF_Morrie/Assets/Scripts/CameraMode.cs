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

    /// <summary>
    /// 자동모드 ui 활성화, 초기화
    /// </summary>
    public void AutoModeSetting()
    {if (b_manualMode) return;

        autoViewfinder.SetActive(true);
        camButton.OnCamButton();
        //카메라버튼에서 b_manualCameraActive false로 두고 ManualCamButton() 실행
    }
    /// <summary>
    /// 수동모드 ui 비활성화
    /// </summary>
    public void ManualModeSetting()
    {if (b_autoMode) return;

        autoViewfinder.SetActive(false);
        maueViewfinder.SetActive(false);
    }
}
