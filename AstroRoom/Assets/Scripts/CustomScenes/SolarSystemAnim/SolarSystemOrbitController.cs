using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SolarSystemOrbitController : MonoBehaviour
{
    public Transform center;
    public float a = 1f; //a is in AU, Semimajor Axis
    private float angle; // angle theta
    [Tooltip("Ile sekund zajmuje pelen obrot")]
    public float speed = 1f;
    private float calculatedSpeed = 1f;
    float x;
    float z;
    public float b = 1f;
    public double orbits = 0f;
    TrailRenderer trail;
    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
        SolarSystemController.Instance.onSizeChange += ClearTrail;
    }
    void FixedUpdate()
    {
        if (speed == 0f)
            return;

        transform.LookAt(center);
        calculatedSpeed = (2 * Mathf.PI) / (1f / speed) * SolarSystemController.Instance.speedMultiplier;
        angle += calculatedSpeed * Time.deltaTime;
        x = Mathf.Cos(angle) * a; // a is the Radius in the x direction
        z = Mathf.Sin(angle) * b; // b is the  Radius in the z direction
        transform.localPosition = new Vector3(x, transform.localPosition.y, z);

        orbits = System.Math.Round((angle * 60f) / 360f, 2);
    }

    void ClearTrail()
    {
        trail.Clear();
    }


}
