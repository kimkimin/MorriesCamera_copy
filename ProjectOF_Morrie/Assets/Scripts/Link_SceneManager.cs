using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Link_SceneManager : MonoBehaviour
{
    AsyncOperation asyncOper;
    bool b_playReady = false;
    // 스프라이트 애님이 로딩되는동안 플레이]
    int nextSceneNum;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLoad());
    }

    public void Ready()
    {
        b_playReady = true;
    }

    IEnumerator StartLoad()
    {
        asyncOper = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + nextSceneNum);
        asyncOper.allowSceneActivation = false;

        while (!asyncOper.isDone)
        {
            yield return null;
            if(asyncOper.progress >= 0.9f)
            {
                if (b_playReady == true) asyncOper.allowSceneActivation = true;
            }
        }
    }
}
