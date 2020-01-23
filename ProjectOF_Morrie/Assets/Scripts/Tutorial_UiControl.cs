using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_UiControl : MonoBehaviour
{
    public GameObject CameraMove, CameraAnchor;
    public GameObject tut1, tut2, tut4, tut5, tut8;
    public BoxCollider2D moryCollider;
    public GameObject PhotoManager;
    Vector3 cameraPos;

    bool isMoved = false;
    bool isZoomed = false;
    bool isPhoto = false;
    bool isPhotoed = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoved)
        {
            tut1.SetActive(false);
            tut2.SetActive(true);
            isMoved = false;
        }

        if (isZoomed && !Play_DragCameraZoom.b_IsTouch2)
        {
            tut5.SetActive(true);
            moryCollider.gameObject.GetComponent<Tutorial_SpineTouch>().PointingAnim();
            isZoomed = false;
        }
        if (isPhotoed)
        {
            tut8.SetActive(true);
            isPhotoed = false;
        }
        
    }

    public void MoveCheck()
    {
        cameraPos = CameraMove.GetComponent<Transform>().position;
        StartCoroutine(MoveChecking());
    }
    public void ZoomCheck()
    {
        StartCoroutine(ZoomChecking());
    }
    public void PhotoCheck()
    {
        StartCoroutine(PhotoChecking());
    }

    public void EndTut()
    {
        CameraAnchor.GetComponent<Animator>().enabled = true;
    }

    IEnumerator MoveChecking()
    {
        if (Vector3.Distance(CameraMove.GetComponent<Transform>().position, cameraPos) > 100)
            isMoved = true;

        if (!isMoved)
        {
            yield return new WaitForSeconds(0);
            StartCoroutine(MoveChecking());
        }
        
    }

    IEnumerator ZoomChecking()
    {
        if (Play_DragCameraZoom.b_IsTouch2)
        {
            tut4.SetActive(false);
            isZoomed = true;
        }

        if (!isZoomed)
        {
            yield return new WaitForSeconds(0);
            StartCoroutine(ZoomChecking());
        }
    }

    IEnumerator PhotoChecking()
    {

        if (PhotoManager.activeSelf == true) isPhoto = true;

        if (isPhoto && !PhotoManager.activeSelf)
        {
            isPhotoed = true;
        }

        if (!isPhotoed)
        {
            yield return new WaitForSeconds(0);
            StartCoroutine(PhotoChecking());
        }
    }
}
