using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Spine_Touch : MonoBehaviour
{
    SkeletonAnimation skeleton;
    Spine_SetAnimList setAnim;
    int animCount;
    int animNum = 0;
    int myTypeNum;

    private void Start()
    {
        skeleton = GetComponent<SkeletonAnimation>();
        setAnim = GetComponent<Spine_SetAnimList>();
        skeleton.loop = true;
        animCount = setAnim.animList.Count;
    }
    private void OnMouseDown()
    {
        //if (Link_touchCheck.touch.phase == TouchPhase.Moved) return;
        //드래그 이동시 스칠때 스파인이 움직이나 확임

        print("imTouched");
        //CheckAnimType(setAnim.animList[animNum+1]);
    }

    /// <summary>
    /// 터치 후 무한루프, 터치를통한 정지,재생
    /// </summary>
    void TG_()
    {//NOT_TESTED
        if (Spine_CSVReader.SplitType(skeleton.AnimationName) == "idle")
            skeleton.AnimationName = setAnim.animList[animNum];
        else if (skeleton.timeScale == 1)
            skeleton.timeScale = 0;
        else if (skeleton.timeScale == 0)
            skeleton.timeScale = 1;
    }
    
    /// <summary>
    /// t1을 한번만 실행한후 idle로 돌아감
    /// </summary>
    IEnumerator RE_()
    {
        skeleton.loop = false;
        animNum++;
        skeleton.AnimationName = setAnim.animList[animNum];
        while (!skeleton.state.GetCurrent(0).IsComplete)
        {
            yield return new WaitForEndOfFrame();
        }
        animNum--;
        skeleton.loop = true;
        skeleton.AnimationName = setAnim.animList[animNum];
    }

    /// <summary>
    /// t1을 한번만 실행한후, 멈춤
    /// </summary>
    void E_()
    {if (animNum > 0) return;

        skeleton.loop = false;
        animNum++;
        skeleton.AnimationName = setAnim.animList[animNum];
    }

    /// <summary>
    /// 터치후 t1을 한번만 실행한후, 멈춤, 추가인터랙션 가능
    /// </summary>
    void L_()
    {
        skeleton.loop = false;
        animNum++;
        skeleton.AnimationName = setAnim.animList[animNum];
    }

    void CheckAnimType(string animName)
    {
        //이거 그냥 소문자버전도 만들까
        //변경된 유형으로 수정하기
        string[] types = { "RE", "L", "E", "TG",  "IN", "E1", "RE1", "RE2", "RE3"};
        string myType = Spine_CSVReader.SplitType(animName);

        for (int i = 0; i < types.Length; i++)
        {
            if(myType == types[i])
            {
                myTypeNum = i;
                break;
            }
        }
        print("실행될 애니메이션 타입은 " + myType);
        switch (myTypeNum)
        {
            case (int)AnimType.Return:
                StartCoroutine(RE_());
                break;
            case (int)AnimType.Loop:
                L_();
                break;
            case (int)AnimType.End:
                E_();
                break;
            default:
                break;
        }
    }

    public enum AnimType
    {
        //이것도 수정해서 다시 어겐엔어겐~
        Return,
        Loop,
        End,
        Toggle,
        Infinite,
        E_Next,
        RE_Next,
        Normal
    }
}
//터치하면 플레이될 애니메이션의 형태에대한 제어
//스파인파일이 하나씩다있어야 확인가능