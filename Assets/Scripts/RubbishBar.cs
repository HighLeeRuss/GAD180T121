using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubbishBar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider.value = 0;
    }

    public void SetMaxRubbish(int rubbish)
    {
        slider.maxValue = rubbish;
        slider.value = rubbish;
    }
    
    public void SetRubbish(int rubbish)
    {
        slider.value = rubbish;
    }

}
