using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SetPropAngle : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles = Vector3.zero;
        //GetComponent<SkeletonAnimation>().skeleton.RootBone.SetLocalPosition(Vector2.zero);
    }
}
