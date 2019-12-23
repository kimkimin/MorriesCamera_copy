using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BigPhotoRoad : MonoBehaviour
{
    //Texture2D getTexture;
    public Image setImage;
    
    public void SetImageTexture()
    {
        setImage.sprite = gameObject.GetComponent<Image>().sprite;
    }
}
