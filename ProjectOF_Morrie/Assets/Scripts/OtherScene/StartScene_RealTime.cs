using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene_RealTime : MonoBehaviour
{
    //1. 시간만 따로 가져와서 변수에 저장하기
    //2. 밤낮을 구분하기
    //3. 구분된거에따라 이미지 변경하기
    int dateTimeMin = 6;
    int dateTimeMax = 18;
    public Image Background;

    // Start is called before the first frame update
    void Start()
    {
        float realHour = System.DateTime.Now.Hour;
        //print(realHour);

        if(realHour >= dateTimeMin && realHour < dateTimeMax)
        {
            Background.color = new Color(1, 1, 1, 1);//이게 나중에는 이미지가 바뀌는걸로
        }
        else
        {
            Background.color = new Color(1, 1, 1, 0.5f);
        }
    }
}
