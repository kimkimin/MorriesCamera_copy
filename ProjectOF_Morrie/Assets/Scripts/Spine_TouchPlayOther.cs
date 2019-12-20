using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

/// <summary>
/// priv_stand01,
/// S1_volleyball_bikini01 02 플레이
/// </summary>
public class Spine_TouchPlayOther : MonoBehaviour
{
    public string[] subject_;
    public string[] object_;
    public SkeletonAnimation objectSkel;
    SkeletonAnimation subjectSkel;
    public int playNum = 1;

    private void Start()
    {
        playNum = 1;
        subjectSkel = GetComponent<SkeletonAnimation>();
    }
    private void OnMouseDown()
    {
        AnimPlay();
    }
    void AnimPlay()
    {
        if (playNum >= subject_.Length) return;

        switch (playNum)
        {
            case 0:// 둘다 E를 플레이
                subjectSkel.AnimationName = subject_[playNum];
                objectSkel.AnimationName = object_[0];
                subjectSkel.loop = true;
                playNum++;
                break;
            case 1:// 주체만 RE를 플레이
                StartCoroutine(Next());
                break;
            default:
                break;

        }
    }

    IEnumerator Next()
    {//NOT_TESTED

        subjectSkel.loop = false;
        subjectSkel.AnimationName = subject_[playNum];//1
        while (!subjectSkel.state.GetCurrent(0).IsComplete)
        {
            yield return new WaitForEndOfFrame();
        }
        objectSkel.AnimationName = object_[1];
        playNum++;
        subjectSkel.loop = true;
        subjectSkel.AnimationName = subject_[playNum];
    }
}
