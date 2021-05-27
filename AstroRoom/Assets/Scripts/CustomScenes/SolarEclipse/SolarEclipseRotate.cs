using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SolarEclipseRotate : MonoBehaviour
{
    public Transform objectToRotate;
    public Transform earth;
    public Transform sun;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    public void Rotate()
    {
        Vector3 rotateAround = earth.position - sun.position;
        float delta = slider.value - objectToRotate.rotation.eulerAngles.y;
        objectToRotate.Rotate(Vector3.up, delta);
    }
}
