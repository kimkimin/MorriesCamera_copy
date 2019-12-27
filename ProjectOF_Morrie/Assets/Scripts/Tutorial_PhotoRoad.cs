using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_PhotoRoad : MonoBehaviour
{
    public Image setImage;
    // Start is called before the first frame update
    private void OnEnable()
    {
        print("이미지 로드" + setImage.sprite);
        setImage.sprite = gameObject.GetComponent<Image>().sprite;
    }
}
