
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

/// <summary>
/// 스킨제어할 Spine의 목록을 가져오고 CSV를 읽어서 스킨을 매칭해줌 
/// </summary>
public class Spine_CSVExecuteSkin : MonoBehaviour
{
    List<string[]> voka = new List<string[]>();
    List<string> skin = new List<string>();
    public SkeletonAnimation[] skeletons;

    // Start is called before the first frame update
    void Start()
    {
        GetVoka("Morries_SpineAnimation_stage1_Skins");
    }

    void GetVoka(string csv)
    {
        var rawCSV = (TextAsset)Resources.Load(csv);
        if (rawCSV == null)
            print("csv is null");
        string modiCSV = rawCSV.text;
        voka = Spine_CSVReader.SplitVoka(modiCSV);

        MatchIdle();
    }
    public void MatchIdle()
    {
        for (int i = 0; i < skeletons.Length; i++)
        {
            CheckSkin(skeletons[i]);
        }
    }

    public void CheckSkin(SkeletonAnimation skelton_)
    {
        skin = Spine_CSVReader.SplitSkin(voka, skelton_.initialSkinName);
        SetAnim(skin, skelton_);
    }

    void SetAnim(List<string> skin_, SkeletonAnimation skeleton_)
    {
        skeleton_.gameObject.GetComponent<Spine_TouchSkin>().skins = skin_;
    }
    
}