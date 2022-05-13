using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SlideAudio(AudioSource aus) 
    {
        aus.volume = slider.value;
    }
}
