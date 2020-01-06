using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobile_SetRotate : MonoBehaviour
{
    public bool isPortrait = false;
    public bool isLandscape = false;
    // Start is called before the first frame update
    void Start()
    {
        if (isPortrait)
            Screen.orientation = ScreenOrientation.Portrait;
        else if (isLandscape)
            Screen.orientation = ScreenOrientation.Landscape;
    }
    
}
