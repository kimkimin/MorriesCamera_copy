using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Tutorial_SpineTouch : MonoBehaviour
{
    public string[] animName;
    public GameObject tut5, tut6;
    SkeletonAnimation skeleton;
    bool isTouced = false;
    // Start is called before the first frame update
    void Start()
    {
        skeleton = GetComponent<SkeletonAnimation>();
    }

    public void PointingAnim()
    {
        int[] Num = { 0, 1 };
        StartCoroutine(E_Next_(Num));
    }

    private void OnMouseDown()
    {
        int[] Num = {2, 3};
        StartCoroutine(E_Next_(Num));
        GetComponent<BoxCollider2D>().enabled = false;

        tut5.SetActive(false);
    }


    IEnumerator E_Next_(int[] num)
    {//NOT_TESTED

        skeleton.loop = false;
        skeleton.AnimationName = animName[num[0]];
        while (!skeleton.state.GetCurrent(0).IsComplete)
        {
            yield return new WaitForEndOfFrame();
        }
        skeleton.loop = true;
        skeleton.AnimationName = animName[num[1]];
        while (!skeleton.state.GetCurrent(0).IsComplete)
        {
            yield return new WaitForEndOfFrame();
        }

        if (isTouced)
        {
            tut6.SetActive(true);
        }
        if (!isTouced)
        {
            isTouced = true;
            GetComponent<BoxCollider2D>().enabled = true;
        }
            
        print("트리 애님 끝!");
    }
}
