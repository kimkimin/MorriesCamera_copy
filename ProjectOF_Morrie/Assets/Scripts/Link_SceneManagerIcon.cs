using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Link_SceneManagerIcon : MonoBehaviour
{
    AsyncOperation asyncOper;
    bool b_playReady = false;

    public GameObject Icon_Loading, icon_Entering;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLoad());
    }

    /// <summary>
    /// 씬 이동 승인
    /// </summary>
    public void Ready()
    {
        b_playReady = true;
    }
    
    /// <summary>
    /// 다음씬 비동기로드
    /// </summary>
    IEnumerator StartLoad()
    {
        asyncOper = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        asyncOper.allowSceneActivation = false;

        while (!asyncOper.isDone)
        {
            yield return null;
            if (asyncOper.progress >= 0.9f)
            {
                if (Icon_Loading != null)
                {
                    Icon_Loading.SetActive(false);
                    icon_Entering.SetActive(true);
                }

                if (b_playReady == true) asyncOper.allowSceneActivation = true;

            }
        }
    }
}
