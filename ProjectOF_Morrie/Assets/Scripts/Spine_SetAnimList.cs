using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spine_SetAnimList : MonoBehaviour
{
    public List<string> animList = new List<string>();

    /// <summary>
    /// 가져온 애니메이션 배열에서 공백을 지우고 리스트를 집어넣어준다
    /// </summary>
    public void SetAnim(List<string> anim)
    {
        //int count = anim.Count;
        for (int i = 0; i < anim.Count; i++)
        {
            //print(anim[0] + "의 " + i);
            
            if (anim[i].Trim() == "")
            {
                //print(anim[0] + "의 " + i + "은 공백");
                anim.RemoveRange(i, anim.Count - i);
                //break;
            }
        }
        animList =  anim;

        if (animList.Count <= 1)
            GetComponent<BoxCollider2D>().enabled = false;
    }
}
