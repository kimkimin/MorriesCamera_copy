using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineTouch : MonoBehaviour
{
    bool b_isIdle = false;
    public bool b_isLoop = false;
    public bool b_playOther = false;

    SkeletonAnimation setAnim;
    public SkeletonAnimation getOtherAnim;

    public List<string> animNameList = new List<string>(0);
    int ListIndex = 0;
    
    
    void Start()
    {
        if (b_playOther)
        {
            setAnim = getOtherAnim;
            if (setAnim.AnimationName != null)
            {
                b_isIdle = true;
                ListIndex = 1;
            }
        }
        else
        {
            setAnim = GetComponent<SkeletonAnimation>();
            if (setAnim.AnimationName != null)//default anim이 있다면 isidle = true
            {
                b_isIdle = true;
                ListIndex = 1;
            }
        }
    }

    private void OnMouseDown()
    {
        //if (Play_CheckTouch.SpineCheck) return;
        OnPlayME();
    }

    public void OnPlayME()
    {
        if (b_isIdle)
        {//0번은 디폴트 애니메이션
            if (ListIndex < animNameList.Count)
            {
                setAnim.loop = false;
                setAnim.AnimationName = animNameList[ListIndex];
                ListIndex++;
                if (ListIndex == animNameList.Count)
                {
                    StartCoroutine(WaitAnimEnd_HaveDefault());
                }
            }
        }
        else
        {
            if (ListIndex < animNameList.Count)
            {
                setAnim.AnimationName = animNameList[ListIndex];
                ListIndex++;
                if (b_isLoop && ListIndex == animNameList.Count)
                {
                    StartCoroutine(WaitAnimEnd_HaveNothing());
                }
            }
        }
    }

    IEnumerator WaitAnimEnd_HaveDefault()
    {
        while (!setAnim.state.GetCurrent(0).IsComplete)
        {
            yield return new WaitForEndOfFrame();
        }
        if (b_isLoop)
        {
            setAnim.loop = true;
            setAnim.AnimationName = animNameList[0];
            ListIndex = 1;
        }
    }
    IEnumerator WaitAnimEnd_HaveNothing()
    {
        while (!setAnim.state.GetCurrent(0).IsComplete)
        {
            yield return new WaitForEndOfFrame();
        }
        setAnim.AnimationName = null;
        ListIndex = 0;
    }
}
