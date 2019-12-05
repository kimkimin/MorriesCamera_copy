using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempRo : MonoBehaviour
{
    Quaternion down, up;

    private void OnEnable()
    {
        GridRotate.LayDown += GoLay;
        GridRotate.StandUp += GoStand;
    }
    private void OnDisable()
    {
        GridRotate.LayDown -= GoLay;
        GridRotate.StandUp -= GoStand;
    }

    // Start is called before the first frame update
    void Start()
    {
        var temp = transform.localRotation;
        up = temp;
        down = temp *= Quaternion.AngleAxis(-50, Vector3.right);

    }

    void GoLay()
    {
        StartCoroutine(LerpRotation_layDown());
    }
    void GoStand()
    {
        StartCoroutine(LerpRotation_standUp());
    }

    IEnumerator LerpRotation_layDown()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, down, 0.1f);
        print("눕는중 " + transform.localRotation + " , " + down);
        yield return new WaitForSeconds(0.05f);
        if(Mathf.Round(transform.localRotation.x *10) > Mathf.Round(down.x * 10))
            StartCoroutine(LerpRotation_layDown());
    }
    IEnumerator LerpRotation_standUp()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, up, 0.1f);
        print("일어나는중 " + transform.localRotation + " , " + up);
        yield return new WaitForSeconds(0.05f);
        if (Mathf.Round(transform.localRotation.x * 10) < Mathf.Round(up.x * 10))
            StartCoroutine(LerpRotation_standUp());
    }
}
