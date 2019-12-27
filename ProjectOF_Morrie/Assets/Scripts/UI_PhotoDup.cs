using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PhotoDup : MonoBehaviour
{
    public GameObject photoPrefab;
    public Transform photoParent;
    

    /// <summary>
    /// 사진을 찍을경우 사진 프리팹 생성
    /// 그다음 하위설정
    /// </summary>
    public void DuplicatePrefab()
    {
        GameObject clone = Instantiate(photoPrefab, photoPrefab.transform.position, Quaternion.identity);
        clone.transform.SetParent(photoParent);
        clone.GetComponent<RectTransform>().localScale = Vector3.one;
        clone.GetComponent<PictureLoad>();
        //픽쳐 로드가 있는지 확인해야하고
        //사진저장후 로드도 바로되는지 확인해야함
    }
}
