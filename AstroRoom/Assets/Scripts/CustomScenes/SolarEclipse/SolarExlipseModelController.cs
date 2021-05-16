using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarExlipseModelController : MonoBehaviour
{
    public Transform moon;
    public Transform earth;
    public Transform sun;
    float calculatedZoom = 1f;
    public Renderer earthMaterial;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(25f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        earth.Rotate(transform.right, -25f);
        moon.Rotate(transform.right, -25f);

    }

    private void Update()
    {
        BigMoon();
        EclipseShadowUpdate();
    }

    void BigMoon()
    {
        Vector3 dir = (Vector3.zero - SolarEclipseController.Instance.moon.position).normalized;
        calculatedZoom = Mathf.Lerp(calculatedZoom, (1f / SolarEclipseController.Instance.zoom), Time.deltaTime * 0.75f);
        moon.localPosition = dir * (-(calculatedZoom));

        dir = (Vector3.zero - SolarEclipseController.Instance.sun.position).normalized;
        sun.localPosition = dir * -2.5f;
    }

    void EclipseShadowUpdate()
    {


        Vector2 direction = (SolarEclipseController.Instance.perfectEclipsePosition - SolarEclipseController.Instance.moon.position).normalized;

        ; if (SolarEclipseController.Instance.deltaPosition < SolarEclipseController.Instance.triggerDistance)
        {
            float calculated = SolarEclipseController.Instance.deltaPosition / SolarEclipseController.Instance.triggerDistance * 0.5f;
            float calculatedY = calculated * direction.y;
            calculatedY = Mathf.Clamp(calculatedY, -.5f, .5f);
            earthMaterial.material.SetVector("_EclipseShadowOffset", new Vector2(calculated * -direction.x, calculatedY));
        }
        else
        {
            earthMaterial.material.SetVector("_EclipseShadowOffset", new Vector2(0.5f * direction.x, 0.5f * Mathf.Sign(direction.y)));
        }
    }
}
