using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Prologue_VidEnd : MonoBehaviour
{
    public Link_SceneManagerIcon ins_sceene;
    public VideoPlayer prologueVid;
    int frameEnd;

    void Start()
    {
        print(prologueVid.frame + " / " + prologueVid.frameCount);
        frameEnd = (int)prologueVid.frameCount;
    }
    // Update is called once per frame
    void Update()
    {
        print(prologueVid.frame + " / " + prologueVid.frameCount);
        if ((int)prologueVid.frame >= frameEnd)
        {
            print("넘어갈땐 말좀해 미친놈아");
            ins_sceene.Ready();
        }
    }
}
