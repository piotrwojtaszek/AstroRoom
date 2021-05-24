using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TestUI : MonoBehaviour
{
    public Slider slider;
    public void Change()
    {
        SimController.Instance.timeStep = slider.value;
    }
}
