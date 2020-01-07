using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SettingFade : MonoBehaviour
{
    public GameObject[] FadeObj;
    public Image[] fadeImage;
    bool isVisible = false;

    private void Start()
    {
        for (int i = 0; i < fadeImage.Length; i++)
        {
            Color fadeColor = new Color(fadeImage[i].color.r, fadeImage[i].color.g, fadeImage[i].color.b, 0);
            fadeImage[i].color = fadeColor;
        }
    }

    public void CheckFade()
    {
        if (isVisible) CallFadeOut();
        else CallFadeIn();
    }

    void CallFadeIn()
    {
        isVisible = true;
        StartCoroutine(FadeIn());
    }
    public void CallFadeOut()
    {
        isVisible = false;
        StartCoroutine(FadeOut());
    }


    IEnumerator FadeIn()
    {
        for (int i = 0; i < FadeObj.Length; i++)
        {
            FadeObj[i].SetActive(true);
        }
        float colorAlpha = fadeImage[0].color.a;

        print("fadeIn");
        while (colorAlpha < 1)
        {
            colorAlpha += 0.5f;
            for (int i = 0; i < fadeImage.Length; i++)
            {
                Color fadeColor = new Color(fadeImage[i].color.r, fadeImage[i].color.g, fadeImage[i].color.b, colorAlpha);
                fadeImage[i].color = fadeColor;
            }
            yield return new WaitForSeconds(0.0f);
        }

    }

    IEnumerator FadeOut()
    {
        float colorAlpha = fadeImage[0].color.a;

        print("fadeOut");
        while(colorAlpha > 0)
        {
            colorAlpha -= 0.5f;
            for (int i = 0; i < fadeImage.Length; i++)
            {
                Color fadeColor = new Color(fadeImage[i].color.r, fadeImage[i].color.g, fadeImage[i].color.b, colorAlpha);
                fadeImage[i].color = fadeColor;
            }
            yield return new WaitForSeconds(0.0f);
        }

        for (int i = 0; i < FadeObj.Length; i++)
        {
            FadeObj[i].SetActive(false);
        }
    }
}
