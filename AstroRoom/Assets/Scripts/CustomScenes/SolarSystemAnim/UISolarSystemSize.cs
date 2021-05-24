using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UISolarSystemSize : MonoBehaviour
{
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void ChangeSize()
    {
        SolarSystemController.Instance.sizeMultiplier = slider.value;
        SolarSystemController.Instance.onSizeChange?.Invoke();
    }
}
