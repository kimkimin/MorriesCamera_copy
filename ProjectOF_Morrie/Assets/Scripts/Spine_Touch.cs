using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.EventSystems;

/// <summary>
/// 애니메이션 타입을 나누고 인터렉션
/// </summary>
public class Spine_Touch : MonoBehaviour
{
    SkeletonAnimation skeleton;
    Spine_SetAnimList setAnim;
    int animCount;
    public int animNum = 0;
    int myTypeNum;
    bool isPlaying = false;

    private void Start()
    {
        animNum = 0;
        skeleton = GetComponent<SkeletonAnimation>();
        setAnim = GetComponent<Spine_SetAnimList>();
        skeleton.loop = true;
        animCount = setAnim.animList.Count;
    }
    private void OnMouseDown()
    {
        if (!this.enabled) return;
        if (Link_touchCheck.touch.phase == TouchPhase.Moved) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;
        //if (EventSystem.current.IsPointerOverGameObject(Link_touchCheck.touch.fingerId) == true) return;
        //드래그 이동시 스칠때 스파인이 움직이나 확임

        //print("imTouched");
#if UNITY_IOS
        binding.LigthHaptic();
#endif
        int checkNext = animNum + 1;
        if (checkNext >= setAnim.animList.Count) return;
        if (isPlaying) return;

        CheckAnimType(setAnim.animList[checkNext]);
    }

    //플레이중에는 다시 플레이되지않게 수정해야함
    /// <summary>
    /// 애님 유형나누고 그에따라 실행
    /// </summary>
    void CheckAnimType(string animName)
    {
        string[] types = { "RE", "E", "E1", "TG", "IN" };
        string myType = Spine_CSVReader.SplitType(animName).Trim();

        for (int i = 0; i < types.Length; i++)
        {
            if(myType == types[i])
            {
                myTypeNum = i;
                //print("anim실행 넘버" + myTypeNum);
                break;
            }
            else
            {
                //print(myType + "매칭실패 " + i + "번째 ");
            }
        }
        switch (myTypeNum)
        {
            case (int)AnimType.Return:
                StartCoroutine(RE_());
                break;
            case (int)AnimType.End:
                E_();
                break;
            case (int)AnimType.E_Next:
                StartCoroutine(E_Next_());
                break;
            case (int)AnimType.Toggle:
                TG_();
                break;
            case (int)AnimType.Infinite:
                IN_();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// t1을 한번만 실행한후 idle로 돌아감
    /// </summary>
    IEnumerator RE_()
    {
        skeleton.loop = false;
        animNum++;
        skeleton.AnimationName = setAnim.animList[animNum].Trim();
        isPlaying = true;
        while (!skeleton.state.GetCurrent(0).IsComplete)
        {
            yield return new WaitForEndOfFrame();
        }

        isPlaying = false;
        if (animNum == setAnim.animList.Count - 1)
        {
            animNum = 0;
            skeleton.loop = true;
            skeleton.AnimationName = setAnim.animList[animNum].Trim();
        }
        else
        {
            skeleton.loop = true;
            skeleton.AnimationName = setAnim.animList[0].Trim();
        }
    }

    /// <summary>
    /// t1을 한번만 실행한후, 멈춤, 추가인터랙션 가능(배열끝이 아니라면)
    /// </summary>
    void E_()
    {//if (animNum > 0) return;
     if (animNum >= setAnim.animList.Count) return;

        skeleton.loop = false;
        animNum++;
        skeleton.AnimationName = setAnim.animList[animNum].Trim();
    }

    /// <summary>
    /// 터치 후 E1을 한번만 실행한후, E2를 바로 실행
    /// </summary>
    IEnumerator E_Next_()
    {//NOT_TESTED
        if(animNum >= setAnim.animList.Count) yield return null;

        skeleton.loop = false;
        animNum++;
        skeleton.AnimationName = setAnim.animList[animNum].Trim();
        isPlaying = true;
        while (!skeleton.state.GetCurrent(0).IsComplete)
        {
            yield return new WaitForEndOfFrame();
        }
        skeleton.loop = true;
        animNum++;
        skeleton.AnimationName = setAnim.animList[animNum].Trim();
        while (!skeleton.state.GetCurrent(0).IsComplete)
        {
            yield return new WaitForEndOfFrame();
        }
        isPlaying = false;
        print(animNum + ", " + skeleton.AnimationName);
    }

    /// <summary>
    /// 터치 후 무한루프, 터치를통한 정지,재생
    /// </summary>
    void TG_()
    {//NOT_TESTED
        if (Spine_CSVReader.SplitType(skeleton.AnimationName) == "idle")
            skeleton.AnimationName = setAnim.animList[animNum].Trim();
        else if (skeleton.timeScale == 1)
            skeleton.timeScale = 0;
        else if (skeleton.timeScale == 0)
            skeleton.timeScale = 1;
    }

    /// <summary>
    /// 터치후 t1을 반복실행, 추가인터랙션 가능
    /// </summary>
    void IN_()
    {//NOT_TESTED
        if (animNum >= setAnim.animList.Count) return;

        skeleton.loop = true;
        animNum++;
        skeleton.AnimationName = setAnim.animList[animNum].Trim();
    }

    public enum AnimType
    {
        Return,
        End,
        E_Next,
        Toggle,
        Infinite,
        Normal
    }
}