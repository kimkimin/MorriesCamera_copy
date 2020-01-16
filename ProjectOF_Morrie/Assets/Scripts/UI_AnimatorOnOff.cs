using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_AnimatorOnOff : MonoBehaviour
{
    public Animator targetAnim;

    public void SetTargetAnimOn()
    {
        targetAnim.enabled = true;
    }
    public void SetTargetAnimOff()
    {
        targetAnim.enabled = false;
    }

    public void SetMyAnimOn()
    {
        GetComponent<Animator>().enabled = true;
    }
    public void SetMyAnimOff()
    {
        GetComponent<Animator>().enabled = false;
    }
}
