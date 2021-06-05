using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemOrbitController : IOrbitsCount
{
    public Transform center;
    public float radius = 1f; //a is in AU, Semimajor Axis
    private float angle; // angle theta
    [Tooltip("Ile sekund zajmuje pelen obrot")]
    public float speed = 1f;
    private float calculatedSpeed = 1f;
    float x;
    float z;
    TrailRenderer trail;
    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
        SolarSystemController.Instance.onSizeChange += ClearTrail;
    }
    public void UpdatePosition()
    {
        if (speed == 0f)
            return;
        calculatedSpeed = (2f * Mathf.PI) / (1f / speed) * SolarSystemController.Instance.speedMultiplier;
        angle += calculatedSpeed * Time.deltaTime;
        x = Mathf.Cos(angle) * radius;
        z = Mathf.Sin(angle) * radius;
        transform.localPosition = new Vector3(x, transform.localPosition.y, z);
        orbitsCount = Mathf.FloorToInt(angle / (Mathf.PI * 2f));

    }

    void ClearTrail()
    {
        trail.Clear();
    }


}
//        transform.LookAt(center);