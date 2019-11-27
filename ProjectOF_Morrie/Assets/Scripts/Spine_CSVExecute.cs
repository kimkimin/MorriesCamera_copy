using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Spine.Unity;

public class Spine_CSVExecute : MonoBehaviour
{
    List<string[]> voka = new List<string[]>();
    List<string> anim = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        GetVoka();
    }

    void GetVoka()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Resource/Morries_SpineAnimation_CSV.csv");
        string source = sr.ReadToEnd();
        voka = Spine_CSVReader.SplitVoka(source);
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
