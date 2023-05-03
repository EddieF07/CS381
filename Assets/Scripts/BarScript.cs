using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    public Slider slider;

    public void setMax(int val)
    {
        slider.maxValue = val;
    }

    public void updateBar(int val)
    {
        slider.value = val;
    }
}
