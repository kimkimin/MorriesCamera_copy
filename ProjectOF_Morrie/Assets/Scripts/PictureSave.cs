using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

/// <summary>
/// 지정 화면 캡쳐 및 저장
/// </summary>
public class PictureSave : MonoBehaviour
{
    public RectTransform renderViewSize;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.height, true);
    }

    public void SavePhoto()
    {
        StartCoroutine(TakeA_Picture());
    }

    IEnumerator TakeA_Picture()
    {
        yield return new WaitForEndOfFrame();
        //한프레임 대기
        
        Texture2D screenShot = new Texture2D(600, 600, TextureFormat.RGB24, false);
       //screenShot.ReadPixels(new Rect(Screen.width/2 - 300, Screen.height/2 - 197, screenShot.width, screenShot.height), 0, 0);
        screenShot.ReadPixels(new Rect(Screen.width/2 - screenShot.width/2, Screen.height/2 - screenShot.height/2, screenShot.width, screenShot.height), 0, 0);
        screenShot.Apply();

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            byte[] bytes = screenShot.EncodeToPNG();
            System.IO.File.WriteAllBytes(Path.Combine(Application.persistentDataPath, "capture.png"), bytes);
        }
        else
        {
            byte[] bytes = screenShot.EncodeToPNG();
            System.IO.File.WriteAllBytes(Path.Combine("D:/MorriesCamera/MorriesCameraUnity/ProjectOF_Morrie/Assets/Image/SavePhoto", "capture.png"), bytes);
        }
    }
}
