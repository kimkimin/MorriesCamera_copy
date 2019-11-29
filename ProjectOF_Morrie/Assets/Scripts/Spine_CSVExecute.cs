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
        GetVoka();
    }

    void GetVoka()
    {
        var csvResource = (TextAsset)Resources.Load("Morries_SpineAnimation_CSV");
        if (csvResource == null)
            print("csv is null");
        string cvsString = csvResource.text;
        //StreamReader sr = new StreamReader(Application.dataPath + "/Resources/Morries_SpineAnimation_CSV.csv");
        //string source = sr.ReadToEnd();
        voka = Spine_CSVReader.SplitVoka(cvsString);//source);

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
        anim = Spine_CSVReader.SplitSkin(voka, skelton_.initialSkinName);
        SetAnim(anim, skelton_);
    }

    void SetAnim(List<string> anim_, SkeletonAnimation skeleton_)
    {
        //print("내스킨 : " + skeleton_.initialSkinName + ", 내아이들 : " + anim_[0]);
        skeleton_.AnimationName = anim_[0];
        skeleton_.gameObject.GetComponent<Spine_SetAnimList>().SetAnim(anim);
    }
}
