using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binding : MonoBehaviour
{
    public static bool HapticActive = false;


    public static void LigthHaptic()
    {
        iOSPlugin._unityHaptic("Light");
    }
    public static void MediumHaptic()
    {
        iOSPlugin._unityHaptic("Medium");
    }
    public static void HeavyHaptic()
    {
        iOSPlugin._unityHaptic("Heavy");
    }
    public static void SuccessHaptic()
    {
        iOSPlugin._unityHaptic("Success");
    }
    public static void WarningHaptic()
    {
        iOSPlugin._unityHaptic("Warning");
    }
    public static void ErrorHaptic()
    {
        iOSPlugin._unityHaptic("Error");
    }

    public void HapticControl()
    {
        if (HapticActive)
            HapticActive = false;
        else
            HapticActive = true;
    }
}
//지금 너가 보는시점으로 저번주에 이거함 실행안시켜봄 해보셈 넹~
