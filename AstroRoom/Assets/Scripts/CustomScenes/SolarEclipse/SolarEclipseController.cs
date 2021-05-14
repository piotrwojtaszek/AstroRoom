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
    public float triggerDistance = 40f;
    List<InputDevice> inputDevices = new List<InputDevice>();
    float xAngle = 0f;
    float yAngle = 0f;
    float distance = 200f;
    [SerializeField]
    [Range(0.75f, 1.75f)]
    float zoom = 1f;
    float deltaPosition = 50f;
    public Slider slider;
    public TextMeshProUGUI uGUI;
    public Transform directionalLight;
    [SerializeField] AnimationCurve curve;
    [SerializeField] AnimationCurve movementMultipier;
    Vector3 perfectEclipsePosition;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateDevices", 0f, 2f);
        moonPivot.RotateAround(Vector3.zero, Vector3.up, 30f);
        moonPivot.RotateAround(Vector3.zero, Vector3.left, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var device in inputDevices)
        {
            device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 inputValue);

            MoonMovement(inputValue);
            MoonAutoMovement(inputValue.magnitude);
        }
        CalculateDeltaPosition();
        ProcessPositionOnAmbientLight();
        ProcessZoom();
        zoom = slider.value;
        uGUI.text = "Zoom: " + slider.value.ToString("F1") + "x";
    }

    void UpdateDevices()
    {
        InputDevices.GetDevices(inputDevices);
    }

    void MoonMovement(Vector2 inputValue)
    {
        float multiplier = 1f;
        if(deltaPosition < triggerDistance)
        {
            multiplier = deltaPosition / triggerDistance;
            multiplier = movementMultipier.Evaluate(multiplier);
        }

        yAngle = Mathf.Lerp(yAngle, inputValue.y, Time.deltaTime * 0.5f);
        xAngle = Mathf.Lerp(xAngle, inputValue.x, Time.deltaTime * 0.5f);
        moonPivot.RotateAround(Vector3.zero, Vector3.up, xAngle * Time.deltaTime * 4f * multiplier);
        moonPivot.RotateAround(Vector3.zero, Vector3.left, yAngle * Time.deltaTime * 4f * multiplier);
    }

    Vector3 GetPerfectEclipsePosition()
    {
        perfectEclipsePosition = (sun.position - Vector3.zero).normalized * (moonPivot.position - Vector3.zero).magnitude;
        return perfectEclipsePosition;
    }

    void ProcessZoom()
    {

        Vector3 newPosition = (moonPivot.position - Vector3.zero).normalized * distance * (1f / zoom);
        moonPivot.position = Vector3.Lerp(moonPivot.position, newPosition, Time.deltaTime * 0.35f);

        newPosition = (sun.position - Vector3.zero).normalized * (distance + 120f) * (1f / zoom);
        sun.position = Vector3.Lerp(sun.position, newPosition, Time.deltaTime * 0.35f);
    }

    void ProcessPositionOnAmbientLight()
    {
        if (deltaPosition < triggerDistance)
        {
            float graph = deltaPosition / triggerDistance;
            graph = curve.Evaluate(graph) * 23f;
            Debug.Log(graph);

            directionalLight.rotation = Quaternion.Euler(10f - graph, 180f, 0f);
        }
    }

    void MoonAutoMovement(float input)
    {
        if (deltaPosition < 4f && input <= 0.1f)
        {
            moonPivot.position = Vector3.Lerp(moonPivot.position, GetPerfectEclipsePosition(), Time.deltaTime * .25f);
        }
    }

    void CalculateDeltaPosition()
    {
        deltaPosition = (moonPivot.position - GetPerfectEclipsePosition()).magnitude;
    }
}
