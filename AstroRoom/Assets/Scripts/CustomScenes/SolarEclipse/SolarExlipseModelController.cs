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
    // Start is called before the first frame update
    void Start()
    {
        /*transform.rotation = Quaternion.Euler(25f, 90f, 0);*/

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
        moonPivot.localPosition = dir * (-.5f - (calculatedZoom));

        dir = (Vector3.zero - SolarEclipseController.Instance.sun.position).normalized;
        sun.localPosition = dir * -3f;
    }

    void EclipseShadowUpdate()
    {
        Vector3 dir = (moonPivot.position - earth.position).normalized;

        earthMaterial.material.SetVector("_EclipseShadowOffset", new Vector2(dir.x+ Mathf.Cos(dir.z), dir.y+ Mathf.Sin(dir.z)));
        Debug.DrawRay(earth.position, dir, Color.red);
        Debug.Log(dir);
    }
}
