using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EndingPageSlider : MonoBehaviour
{
    public GameObject[] pages;
    int pagesNum = 1;
    bool pageEnd = true;
    

    public void NextPage()
    {
        print("??");
        if (pagesNum >= pages.Length) return;
        if (!pageEnd) return;

        pages[pagesNum].SetActive(true);
        pagesNum++;
        pageEnd = false;
    }

    public void CheckPageStart()
    {
        pageEnd = true;
    }
}
