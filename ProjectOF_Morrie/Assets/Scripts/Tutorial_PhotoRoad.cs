using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_PhotoRoad : MonoBehaviour
{
    public Image setImage;
    // Start is called before the first frame update
    void Start()
    {// is enable 해야하나?
        setImage.sprite = gameObject.GetComponent<Image>().sprite;
    }
}
