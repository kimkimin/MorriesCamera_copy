using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjects_OnOff : MonoBehaviour
{
    public GameObject[] activate;
    public GameObject[] deactivate;

    public void ActivateControl_onoff()
    {
        for (int i = 0; i < activate.Length; i++)
        {
            activate[i].SetActive(true);
        }
        for (int i = 0; i < deactivate.Length; i++)
        {
            deactivate[i].SetActive(false);
        }
    }
}
