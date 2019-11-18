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
        GameObject clone = Instantiate(photoPrefab, Vector3.zero, Quaternion.identity);
        clone.transform.SetParent(photoParent);
    }
}
