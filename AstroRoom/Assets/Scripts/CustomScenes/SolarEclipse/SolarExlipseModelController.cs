using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarExlipseModelController : MonoBehaviour
{
    public Transform moonPivot;
    public Transform earth;
    public Transform sun;
    float calculatedZoom = 1f;
    public Renderer earthMaterial;
    public Vector4 eclipseOffset;
    public Vector2 offset;
    public AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(25f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        earth.Rotate(transform.right, -25f);
        moonPivot.Rotate(transform.right, -25f);

    }

    private void Update()
    {
        BigMoon();
        EclipseShadowUpdate();
    }

    void BigMoon()
    {
        Vector3 dir = (Vector3.zero - SolarEclipseController.Instance.moonPivot.position).normalized;
        calculatedZoom = Mathf.Lerp(calculatedZoom, (1f / SolarEclipseController.Instance.zoom), Time.deltaTime * 0.75f);
        moonPivot.localPosition = dir * (-(calculatedZoom));

        dir = (Vector3.zero - SolarEclipseController.Instance.sun.position).normalized;
        sun.localPosition = dir * -2.5f;
    }

    void EclipseShadowUpdate()
    {


        Vector2 direction = (SolarEclipseController.Instance.perfectEclipsePosition - SolarEclipseController.Instance.moonPivot.position).normalized;

        if (SolarEclipseController.Instance.deltaPosition < SolarEclipseController.Instance.triggerDistance)
        {
            float calculated = SolarEclipseController.Instance.deltaPosition / SolarEclipseController.Instance.triggerDistance * 0.5f;
            earthMaterial.material.SetVector("_EclipseShadowOffset", new Vector2(calculated * -direction.x, calculated * direction.y));
        }
        else
        {
            earthMaterial.material.SetVector("_EclipseShadowOffset", new Vector2(0.5f * direction.x, 0.5f * direction.y));
        }
    }
}
