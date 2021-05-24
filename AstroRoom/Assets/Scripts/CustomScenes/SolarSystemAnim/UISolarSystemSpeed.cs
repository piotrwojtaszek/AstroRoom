using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UISolarSystemSpeed : MonoBehaviour
{
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();    
    }

    public void ChangeSpeed()
    {
        SolarSystemController.Instance.speedMultiplier = slider.value;
    }
}
