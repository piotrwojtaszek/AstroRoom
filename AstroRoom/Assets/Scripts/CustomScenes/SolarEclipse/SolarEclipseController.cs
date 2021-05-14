using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using TMPro;
public class SolarEclipseController : MonoBehaviour
{
    public Transform moonPivot;
    public Transform sun;

    List<InputDevice> inputDevices = new List<InputDevice>();
    float xAngle = 0f;
    float yAngle = 0f;
    float distance = 200f;
    [SerializeField]
    [Range(0.75f, 1.75f)]
    float zoom = 1f;
    public Slider slider;
    public TextMeshProUGUI uGUI;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateDevices", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var device in inputDevices)
        {
            device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 inputValue);
            yAngle = Mathf.Lerp(yAngle, inputValue.y, Time.deltaTime * 0.4f);
            xAngle = Mathf.Lerp(xAngle, inputValue.x, Time.deltaTime * 0.4f);
            moonPivot.RotateAround(Vector3.zero, Vector3.up, xAngle * Time.deltaTime * 5f);
            moonPivot.RotateAround(Vector3.zero, Vector3.left, yAngle * Time.deltaTime * 5f);
        }
        ProcessZoom();
        zoom = slider.value;
        uGUI.text = "ZOOM: " + slider.value.ToString("F1") + "x";
    }

    void UpdateDevices()
    {
        InputDevices.GetDevices(inputDevices);
    }

    private void OnDrawGizmos()
    {
        Vector3 dir = (sun.position - Vector3.zero).normalized;
        float dst = (moonPivot.position - Vector3.zero).magnitude;
        Gizmos.DrawSphere(dir * dst, 10f);
    }

    void ProcessZoom()
    {

        Vector3 newPosition = (moonPivot.position - Vector3.zero).normalized * distance * (1f / zoom);
        moonPivot.position = Vector3.Lerp(moonPivot.position, newPosition, Time.deltaTime * 0.35f);
    }
}
