using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public int SceneNum;

    public void GoSceneWithNum()
    {
        SceneManager.LoadScene(SceneNum);
    }
}
