using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public float SliderValue;

    void Start()
    {
        slider.value = SliderValue;
    }
    
    public void ChangeSlider(float value)
    {
        SliderValue = value;
    }
}
