using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRotate : MonoBehaviour
{
    [Tooltip("VECTOR, grid가 회전될 각도입니다.")]
    public Vector3 gridROT;
    [Tooltip("FLOAT, grid의 회전시점을 정하는 zoom 값")]
    public float Zoom_RealMin;
    [Tooltip("BOOL, Play_MouseGapMove에서 줌체크로 사용됨")]
    public bool isZoomin = false;

    public GameObject Cam;
    public GameObject GridForImage, GridForCam;
    // Update is called once per frame
    void Update()
    {
        /*
        if (Cam.GetComponent<Camera>().fieldOfView < Zoom_RealMin)//zoom in
        {
            float SpeedClamp = Mathf.Clamp(Mathf.Abs(ins_zoom.FrameChangeForGridRot), 40, 450);
            GridForImage.transform.eulerAngles =
                Vector3.MoveTowards(GridForImage.transform.eulerAngles, gridROT, Time.deltaTime * SpeedClamp);
            //field of view를 그대로 쓰면 30~100까지의 범위를 갖고있는 값은 줌아웃을 할경우 더 빠를수밖에 없음 
            //변화된 양을 곱해줘야합니다.0612

            gameObject.transform.eulerAngles = GridForImage.transform.eulerAngles;
            GridForCam.transform.eulerAngles = GridForImage.transform.eulerAngles;
            isZoomin = true;
        }
        else//zoom out
        {
            isZoomin = false;
            float SpeedClamp = Mathf.Clamp(Mathf.Abs(ins_zoom.FrameChangeForGridRot), 40, 450);
            GridForImage.transform.eulerAngles =
                Vector3.MoveTowards(GridForImage.transform.eulerAngles, Vector3.zero, Time.deltaTime * SpeedClamp);

            gameObject.transform.eulerAngles = GridForImage.transform.eulerAngles;
            GridForCam.transform.eulerAngles = GridForImage.transform.eulerAngles;
        }*/
        Cam.transform.position = transform.position;
    }
}
