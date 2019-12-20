using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

/// <summary>
/// priv_stanc02, S1_surfing_pants wave 플레이
/// </summary>
public class Spine_TouchPlayOther2 : MonoBehaviour
{
    public string[] subjectAnim;
    public string[] objectAnim;
    SkeletonAnimation subjectSkel;
    public SkeletonAnimation objectSkel;
    public int playNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        playNum = 0;
        subjectSkel = GetComponent<SkeletonAnimation>();
    }

    private void OnMouseDown()
    {
        StartCoroutine(RE_());
        //AnimPlay();
    }
    /*
    void AnimPlay()
    {
        switch (playNum)
        {
            case 0:// RE
                break;
            case 1:// 주체만 RE를 플레이
                break;
            default:
                break;

        }
    }*/

    /// <summary>
    /// t1을 한번만 실행한후 idle로 돌아감
    /// </summary>
    IEnumerator RE_()
    {
        subjectSkel.loop = false;
        objectSkel.loop = false;
        playNum++;
        subjectSkel.AnimationName = subjectAnim[playNum].Trim();
        objectSkel.AnimationName = objectAnim[playNum].Trim();
        while (!subjectSkel.state.GetCurrent(0).IsComplete)
        {
            yield return new WaitForEndOfFrame();
        }
        if (playNum == subjectAnim.Length - 1)
        {
            playNum = 0;
            subjectSkel.loop = true;
            objectSkel.loop = true;
            subjectSkel.AnimationName = subjectAnim[playNum].Trim();
            objectSkel.AnimationName = objectAnim[playNum].Trim();
        }
        else
        {
            subjectSkel.loop = true;
            objectSkel.loop = true;
            subjectSkel.AnimationName = subjectAnim[0].Trim();
            objectSkel.AnimationName = objectAnim[0].Trim();
        }
    }
}
