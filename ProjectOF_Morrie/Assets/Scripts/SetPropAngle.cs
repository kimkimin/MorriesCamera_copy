using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SetPropAngle : MonoBehaviour
{
    Vector3 tepmp;
    private void Start()
    {
        tepmp = GetComponent<Transform>().eulerAngles;
    }
    void Update()
    {
        transform.eulerAngles = tepmp;//Vector3.zero;
        //GetComponent<SkeletonAnimation>().skeleton.RootBone.SetLocalPosition(Vector2.zero);
    }
}
