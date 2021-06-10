using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SolarEclipseChangeMode : MonoBehaviour
{
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void OnValueChange()
    {
        if (slider.value == 0)
            SolarEclipseController.Instance.isSkybox = false;
        else
            SolarEclipseController.Instance.isSkybox = true;
        SolarEclipseController.Instance.ChangeSkyboxMode();
    }
}
