using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using System.Text.RegularExpressions;

public class Spine_TouchSkin : MonoBehaviour
{
    public List<string> skins;
    SkeletonAnimation skeleton_;
    int skinNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        //print(splitVoka.) //
        //이렇게 전부 나눠서 기존실행자에서 나눠 실행시키거나 그냥 따로 스크립트를 생성하거나.

        skeleton_ = GetComponent<SkeletonAnimation>();
    }

    private void OnMouseDown()
    {
        SkinChange();
    }

    void SkinChange()
    {if (skinNum == skins.Count - 1) return;

        print("touched");
        skinNum++;
        //skeleton.initialSkinName = skins[skinNum];
        print(skins[skinNum]);
        skeleton_.skeleton.SetSkin(skins[skinNum]);
        skeleton_.skeleton.SetSlotsToSetupPose();
        skeleton_.LateUpdate();
    }
}

