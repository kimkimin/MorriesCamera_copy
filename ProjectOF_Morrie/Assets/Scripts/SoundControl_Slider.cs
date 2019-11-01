using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl_Slider : MonoBehaviour
{
    public AudioSource Sound;
    public void SoundSlider()
    {
        Sound.volume = GetComponent<Slider>().value;
    }
}
