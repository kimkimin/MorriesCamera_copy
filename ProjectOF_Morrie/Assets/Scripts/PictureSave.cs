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
        //Screen.SetResolution(1080, 1920, true);
    }

    public void SavePhoto()
    {
        StartCoroutine(TakeA_Picture());
    }

    IEnumerator TakeA_Picture()
    {
        yield return new WaitForEndOfFrame();
        //한프레임 대기

        Vector2 readArea = ScalableArea(new Vector2(1080 / 2 - 300, 1920 / 2 - 197));
        Vector2 readTexture = ScalableArea(new Vector2(600, 600));
        //Texture2D screenShot = new Texture2D(600, 600, TextureFormat.RGB24, false);
        //screenShot.ReadPixels(new Rect(Screen.width/2 - 300, Screen.height/2 - 197, screenShot.width, screenShot.height), 0, 0);
        Texture2D screenShot = new Texture2D((int)readTexture.x, (int)readTexture.x, TextureFormat.RGB24, false);
        screenShot.ReadPixels(new Rect(readArea.x, readArea.y, screenShot.width, screenShot.height), 0, 0);
        //print(new Vector2(Screen.width / 2 - 300, Screen.height / 2 - 197));

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

    /// <summary>
    /// 사진이 저장될때마다 해상도를 확인하여 확인된 해상도에 맞게 read범위와 사이즈를 수정한다.
    /// </summary>
    Vector2 ScalableArea(Vector2 baseArea)
    {
        Vector2 baseScreen = new Vector2(1080, 1920);
        Vector2 devideArea = new Vector2(baseArea.x / baseScreen.x, baseArea.y / baseScreen.y);
        Vector2 reviseArea = new Vector2(devideArea.x * Screen.width, devideArea.y * Screen.height);

        return reviseArea;
    }
}
