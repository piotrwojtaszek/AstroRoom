using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SolarEclipseScale : MonoBehaviour
{
    public Transform objectToChange;

    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }


    // Update is called once per frame
    public void Move()
    {
        objectToChange.transform.localScale = Vector3.one * slider.value;
    }
}
