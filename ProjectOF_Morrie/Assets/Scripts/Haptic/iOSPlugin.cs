using UnityEngine;
using System.Runtime.InteropServices;

public class iOSPlugin : MonoBehaviour
{
#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void unityHaptic(string type);

    public static void _unityHaptic(string type)
    {
        unityHaptic(type);
    }
#else

    public static void _unityHaptic(string type){
    Debug.LogError("not this platform");
    }
#endif
}
