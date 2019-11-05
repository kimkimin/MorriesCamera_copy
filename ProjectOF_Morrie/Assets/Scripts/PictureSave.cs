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
    public RectTransform getReadSize;
    //public bool can
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.height, true);
        //아직 옮겨놓지 않음 
        //이미지 캡쳐가 고정이라 새로 지정해도 괜찮을거같음
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
