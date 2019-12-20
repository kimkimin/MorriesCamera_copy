using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image_Touch : MonoBehaviour
{
    public GameObject[] activate;
    public GameObject[] deactivate;

    private void OnMouseDown()
    {
        ActivateControl_onoff();
    }

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
