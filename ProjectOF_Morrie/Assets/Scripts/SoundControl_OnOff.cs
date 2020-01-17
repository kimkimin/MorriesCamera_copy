using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl_OnOff : MonoBehaviour
{
    public AudioSource targetSound;

    public void SoundOn()
    {
        targetSound.mute = false;
    }

    public void SoundOff()
    {
        targetSound.mute = true;
    }
}
