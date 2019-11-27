using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spine_SetAnimList : MonoBehaviour
{
    public List<string> animList = new List<string>();

    public void SetAnim(List<string> anim)
    {
        animList = anim;
        for (int i = 0; i < animList.Count; i++)
        {
            if(animList[i] == "")
            {
                print(i);
                animList.RemoveRange(i, animList.Count);
                break;
            }
        }
    }
    //이상하다 이게왜 안되지 여기서부터 다시하세요 배열에서 공백없애기 시봘
}
