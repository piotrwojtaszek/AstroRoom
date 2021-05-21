using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TestUI : MonoBehaviour
{
    public TextMeshProUGUI textTimeStep;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = SimController.Instance.timeStep;
        textTimeStep.text = SimController.Instance.timeStep.ToString("F3");
    }
    public void Change()
    {
        SimController.Instance.timeStep = slider.value;
    }
}
