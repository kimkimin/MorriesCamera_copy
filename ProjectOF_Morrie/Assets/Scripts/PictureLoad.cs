using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class PictureLoad : MonoBehaviour
{
    Texture2D CustomTexture;
    string LoadImageName = "capture.png";

    public void LoadA_Picture()
    {
        CustomTexture = new Texture2D(
            (int)GetComponent<RectTransform>().rect.width,
            (int)GetComponent<RectTransform>().rect.height);

        if (SystemInfo.deviceType == DeviceType.Handheld)//기기가 모바일인 경우
        {
            Texture2D LoadTextureA = OnAndroid(Path.Combine(Application.persistentDataPath, LoadImageName));
            GetComponent<Image>().sprite =
                Sprite.Create(LoadTextureA, new Rect(0, 0, LoadTextureA.width, LoadTextureA.height), transform.position);
        }
        else
        {
            Texture2D LoadTextureP = OnPc(Path.Combine("D:/MorriesCamera/MorriesCameraUnity/ProjectOF_Morrie/Assets/Image/SavePhoto", LoadImageName));
            GetComponent<Image>().sprite =
                Sprite.Create(LoadTextureP, new Rect(0, 0, LoadTextureP.width, LoadTextureP.height), transform.position);
        }
    }

    Texture2D OnAndroid(string andPath)
    {
        Texture2D texM = null;
        if (File.Exists(andPath))
        {
            byte[] andfileDATA = File.ReadAllBytes(andPath);
            texM = CustomTexture;
            texM.LoadImage(andfileDATA);
            return texM;
        }
        return null;
    }

    Texture2D OnPc(string pcPath)
    {
        Texture2D texP;
        if (File.Exists(pcPath))//4. 받아온 주소에 파일이 존재한다면
        {
            byte[] pcfileDATA = File.ReadAllBytes(pcPath);
            texP = CustomTexture;
            texP.LoadImage(pcfileDATA);
            return texP;
        }
        return null;
    }
}
