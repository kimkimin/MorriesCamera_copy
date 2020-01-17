using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioSource soundEffect;
    //public AudioSource soundBgm;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            soundEffect.Play();
    }
    

    /*
    public void SoundOffBgm()
    {
        soundBgm.Stop();
    }
    public void SoundOnBgm()
    {
        soundBgm.Play();
    }

    public void SoundOffEffect()
    {
        soundEffect.Stop();
    }
    public void SoundOnEffect()
    {
        soundEffect.Play();
    }*/
}
