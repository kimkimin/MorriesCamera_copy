using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Spine.Unity;

/// <summary>
/// Spine의 목록을 가져오고 CSV를 읽어서 애니메이션을 매칭해줌
/// </summary>
public class Spine_CSVExecute : MonoBehaviour
{
    List<string[]> voka = new List<string[]>();
    List<string> anim = new List<string>();
    public SkeletonAnimation[] skeletons;
    
    // Start is called before the first frame update
    void Start()
    {
        GetVoka("Morries_SpineAnimation_stage1_Character7");
    }

    /// <summary>
    /// csv를 text로 변경하여 단어배열 가져옴
    /// </summary>
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

    /// <summary>
    /// 스켈레톤을 가져와서 해당 스킨명과 비교하여 애님배열 가져옴
    /// </summary>
    public void CheckSkin(SkeletonAnimation skelton_)
    {
        anim = Spine_CSVReader.SplitAnim(voka, skelton_.initialSkinName);
        SetAnim(anim, skelton_);
    }

    void SetAnim(List<string> anim_, SkeletonAnimation skeleton_)
    {
        //print("내스킨 : " + skeleton_.initialSkinName + ", 내아이들 : " + anim_[0]);
        skeleton_.AnimationName = anim_[0];
        skeleton_.gameObject.GetComponent<Spine_SetAnimList>().SetAnim(anim);
    }
}
