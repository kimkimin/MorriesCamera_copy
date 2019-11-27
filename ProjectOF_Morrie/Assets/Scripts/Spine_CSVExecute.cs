using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Spine.Unity;

public class Spine_CSVExecute : MonoBehaviour
{
    SkeletonAnimation mySk;
    List<string[]> voka = new List<string[]>();
    List<string> anim = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Resource/Morries_SpineAnimation_CSV.csv");
        string source = sr.ReadToEnd();
        mySk = GetComponent<SkeletonAnimation>();
        print(mySk.initialSkinName);

        GetVoka(source);
        //List<Dictionary<string, string>> dictList = Spine_CSVReader.Reader(source);

    }

    void GetVoka(string csv)
    {
        voka = Spine_CSVReader.SplitVoka(csv);
        anim = Spine_CSVReader.SplitSkin(voka, mySk.initialSkinName);
        SetAnim(anim);
    }

    void SetAnim(List<string> anim_)
    {
        print("내스킨 : " + mySk.initialSkinName + ", 내아이들 : " + anim_[0]);
        mySk.AnimationName = anim_[0];
    }
}
