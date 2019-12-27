using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_InteractionControl : MonoBehaviour
{
    public Spine_CSVExecute CSVcharacter;
    public Spine_CSVExecute CSVprob;

    public GameObject TouchManager;
    public GameObject PhotoManager;
    public Play_DragCameraZoom ZoomManager;
    public Play_AnswerCheck ManuPhotoManager;
    public GameObject afterZoom, afterPhoto, afterManuPhoto, afterBigPhoto;
    public GameObject Gallery, BigPhoto;

    bool isZoom = false;
    bool stopCheckZoom = false;
    bool isPhoto = false;
    bool stopCheckPhoto = false;
    bool isManuPhoto = false;
    bool isManuPhoto1 = false;
    bool stopCheckManuPhoto = false;
    //bool isBigPhoto = false;
    bool stopCheckBigPhoto = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CSVcharacter.skeletons.Length; i++)
        {
            CSVcharacter.skeletons[i].gameObject.GetComponent<Spine_Touch>().enabled = false;
        }
        for (int i = 0; i < CSVprob.skeletons.Length; i++)
        {
            CSVprob.skeletons[i].gameObject.GetComponent<Spine_Touch>().enabled = false;
        }
        TouchManager.SetActive(false);
        ZoomManager.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopCheckZoom)
        {
            if (Play_DragCameraZoom.b_IsTouch2) isZoom = true;

            if (isZoom && !Play_DragCameraZoom.b_IsTouch2)
            {
                stopCheckZoom = true;
                afterZoom.SetActive(true);
                isZoom = false;
            }
        }

        if (!stopCheckPhoto)
        {
            if (PhotoManager.activeSelf == true) isPhoto = true;

            if (isPhoto && !PhotoManager.activeSelf)
            {
                afterPhoto.SetActive(true);
                stopCheckPhoto = true;
            }
        }

        if (!stopCheckManuPhoto)
        {
            if (ManuPhotoManager.b_isSizeFit) isManuPhoto = true;
            if (isManuPhoto && PhotoManager.activeSelf) isManuPhoto1 = true;

            if(isManuPhoto1 && !PhotoManager.activeSelf)
            {
                afterManuPhoto.SetActive(true);
                stopCheckManuPhoto = true;
            }
        }

        if (!stopCheckBigPhoto)
        {
            if (BigPhoto.activeSelf)
            {
                afterBigPhoto.SetActive(true);
                stopCheckBigPhoto = true;
            }
        }
    }

    public void TouchControl()
    {
        TouchManager.SetActive(true);
    }

    public void ZoomControl()
    {
        ZoomManager.enabled = true;
    }

    public void GalleryControl()
    {
        Gallery.SetActive(true);
    }

    public void StopTutorial()
    {
        for (int i = 0; i < CSVcharacter.skeletons.Length; i++)
        {
            CSVcharacter.skeletons[i].gameObject.GetComponent<Spine_Touch>().enabled = true;
        }
        for (int i = 0; i < CSVprob.skeletons.Length; i++)
        {
            CSVprob.skeletons[i].gameObject.GetComponent<Spine_Touch>().enabled = true;
        }

        gameObject.SetActive(false);
    }
    /*
    public void Cloning()
    {
        RectTransform[] getChild = originParent.gameObject.GetComponentsInChildren<RectTransform>();
        print(getChild.Length);

        for (int i = 0; i < getChild.Length; i++)
        {
            if(getChild[i].gameObject.tag == "Photo")
            {
                TutorialClone(getChild[i].gameObject, newParent);
                TutorialClone(getChild[i].gameObject, newParent2);
            }
        }
        //TutorialClone()
    }

    public void TutorialClone(GameObject prefab, Transform parent)
    {
        GameObject clone = Instantiate(prefab, prefab.transform.position, Quaternion.identity);
        clone.transform.SetParent(parent);
        clone.GetComponent<RectTransform>().localScale = Vector3.one;
        clone.GetComponent<PictureLoad>();
    }*/
}
