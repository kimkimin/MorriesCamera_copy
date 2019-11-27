using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

/// <summary>
/// Spine 목록을 가져오고
/// </summary>
public class Spine_GetAllList : MonoBehaviour
{
    public SkeletonAnimation[] skeletons;
    public Spine_CSVExecute CSVExecute;
    //public string[] skins;

    // Start is called before the first frame update
    void Start()
    {
        MatchIdle();
    }

    public void MatchIdle()
    {
        for (int i = 0; i < skeletons.Length; i++)
        {
            CSVExecute.CheckSkin(skeletons[i]);
        }
    }
    
}
