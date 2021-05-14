using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MoonRotator : MonoBehaviour
{
    [SerializeField]
    InputDeviceCharacteristics deviceCharacteristics;
    InputDevice targetDevice;
    [SerializeField] Rigidbody moonPivot;
    [SerializeField] float forceMultiplier;
    [SerializeField] Transform directionalLight;
    [SerializeField] Transform target;//poit where is total eclipse
    [SerializeField] AnimationCurve curve;
    Color normal = new Color(1f, 0.9380f, 0.9009f, 1f);
    [SerializeField] Renderer moonRenderer = null;
    Color normalMoonColor;
    [SerializeField] Renderer eclipseBloom = null;
    Color normalEclipseColor = new Color(1f, 1f, 1f, 0f);
    private void Start()
    {
        //moonRenderer = moonPivot.gameObject.GetComponent<Renderer>();
        normalMoonColor = moonRenderer.material.GetColor("_BaseColor");
    }
    void Update()
    {
        if (!targetDevice.isValid)
        {
            UpdateDevices();
        }

        float distance = Vector3.Distance(moonPivot.transform.position, target.position);
        if (distance < 30f)
        {
            float graph = 1f - curve.Evaluate(distance / 30f);

            float posX = 15f - graph * 30f;
            directionalLight.eulerAngles = new Vector3(posX, directionalLight.eulerAngles.y, directionalLight.eulerAngles.z);

            Color temp = new Color(normal.r - graph / 5f, normal.g - graph / 4f, normal.b - graph / 4f, 1f);
            Color tempMoon = new Color(normalMoonColor.r * (1f - graph), normalMoonColor.g * (1f - graph), normalMoonColor.b * (1f - graph), 1f);
            Color tempEclipse = new Color(1f, 1f, 1f, graph);
            moonRenderer.material.SetColor("_BaseColor", tempMoon);
            eclipseBloom.material.SetColor("_BaseColor", tempEclipse);
            RenderSettings.ambientLight = temp;
            GetValue(1f - graph);
        }
        else
        {
            directionalLight.eulerAngles = new Vector3(15f, directionalLight.eulerAngles.y, directionalLight.eulerAngles.z);
            moonRenderer.material.SetColor("_BaseColor", normalMoonColor);
            eclipseBloom.material.SetColor("_BaseColor", normalEclipseColor);
            RenderSettings.ambientLight = normal;
            GetValue(1f);
        }

    }

    public void GetValue(float multi)
    {
        Vector2 discardedValue;
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out discardedValue))
        {
            multi = Mathf.Clamp(multi, 0.1f, 1f);
            moonPivot.AddForce(transform.up * discardedValue.y * forceMultiplier * multi);
            moonPivot.AddForce(transform.right * discardedValue.x * forceMultiplier * multi);
        }
    }

    void UpdateDevices()
    {
        List<InputDevice> inputDevices = new List<InputDevice>();
        InputDeviceCharacteristics controllerCharacteristics = deviceCharacteristics | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, inputDevices);

        foreach (var item in inputDevices)
        {
            Debug.Log(item.name);
        }

        if (inputDevices.Count > 0)
        {
            targetDevice = inputDevices[0];
        }
    }
}