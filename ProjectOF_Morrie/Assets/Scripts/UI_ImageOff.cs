using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ImageOff : MonoBehaviour
{
    public Image[] targetImage;

    public void ImageOff()
    {
        Color getColor = targetImage[0].color;
        for (int i = 0; i < targetImage.Length; i++)
        {
            targetImage[i].color = new Color(getColor.r, getColor.g, getColor.b, 0);
        }
    }
    public void ImageOn()
    {
        Color getColor = targetImage[0].color;
        for (int i = 0; i < targetImage.Length; i++)
        {
            targetImage[i].color = new Color(getColor.r, getColor.g, getColor.b, 1);
        }
    }
}
