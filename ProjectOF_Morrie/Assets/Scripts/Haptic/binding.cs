using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binding : MonoBehaviour
{
    public static void LigthHaptic(){
        iOSPlugin._unityHaptic("Light");
    }
}
