using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjects_Switch : MonoBehaviour
{
    bool b_switch;
    public bool b_setTrue;
    public List<GameObject> activateObject;

    /// <summary>
    /// 클릭할때 on off 변경
    /// </summary>
    public void ActivateControl_switch()
    {
        if (b_setTrue) b_switch = true;
        else b_switch = !b_switch;

        for (int i = 0; i < activateObject.Count; i++)
        {
            activateObject[i].SetActive(b_switch);
        }
    }
}
