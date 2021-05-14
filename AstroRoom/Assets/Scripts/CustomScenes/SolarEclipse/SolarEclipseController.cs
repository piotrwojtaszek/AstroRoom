using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SolarEclipseController : MonoBehaviour
{
    public Transform moonPivot;
    public Transform sun;

    List<InputDevice> inputDevices = new List<InputDevice>();
    float xAngle = 0f;
    float yAngle = 0f;
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
            /* Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.characteristics));*/
            device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 inputValue);
            yAngle = Mathf.Lerp(yAngle, inputValue.y, 0.01f);
            xAngle = Mathf.Lerp(xAngle, inputValue.x, 0.01f);
            moonPivot.RotateAround(Vector3.zero, Vector3.up, xAngle * Time.deltaTime * 10f);
            moonPivot.RotateAround(Vector3.zero, Vector3.left, yAngle * Time.deltaTime * 10f);

            /*  Debug.Log(inputValue);*/
        }
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
}
