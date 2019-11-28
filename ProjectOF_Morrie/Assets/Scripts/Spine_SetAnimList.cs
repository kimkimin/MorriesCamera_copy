using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spine_SetAnimList : MonoBehaviour
{
    public List<string> animList = new List<string>();

    public void SetAnim(List<string> anim)
    {
        int count = anim.Count;
        for (int i = 0; i < anim.Count; i++)
        {
            if(anim[i] == "")
            {
                anim.RemoveRange(i, anim.Count - i);
                break;
            }
        }
        animList = anim;
    }
}
