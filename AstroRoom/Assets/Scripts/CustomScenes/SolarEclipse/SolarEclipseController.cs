using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using TMPro;
public class SolarEclipseController : MonoBehaviour
{
    public static SolarEclipseController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SolarEclipseController>();
            }

            return _instance;
        }
    }
    private static SolarEclipseController _instance;
    public Transform moon;
    public Transform sun;
    public float triggerDistance = 40f;
    List<InputDevice> inputDevices = new List<InputDevice>();
    float xAngle = 0f;
    float yAngle = 0f;
    float distance = 200f;
    [Range(0.4f, 1f)]
    public float zoom = 1f;
    public float deltaPosition = 50f;
    public Slider slider;
    public Transform directionalLight;
    [SerializeField] AnimationCurve curve;
    [SerializeField] AnimationCurve movementMultipier;
    public Vector3 perfectEclipsePosition;
    Color normal = new Color(1f, 0.9380f, 0.9009f, 1f);
    public Renderer bloomTexture;
    public bool isSkybox = true;
    public Renderer sunMaterial;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateDevices", 0f, 2f);
        moon.RotateAround(Vector3.zero, Vector3.up, 20f);
        moon.RotateAround(Vector3.zero, Vector3.left, 40f);

    }

    // Update is called once per frame
    void Update()
    {

            var inputValue =new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


            MoonMovement(inputValue);


            MoonAutoMovement(inputValue.magnitude);
        
        CalculateDeltaPosition();
        ProcessPositionOnAmbientLight();
        ProcessZoom();
        zoom = slider.value;
    }

    void UpdateDevices()
    {
        InputDevices.GetDevices(inputDevices);
    }

    void MoonMovement(Vector2 inputValue)
    {
        float multiplier = 1f;
        if (deltaPosition < triggerDistance)
        {
            multiplier = deltaPosition / triggerDistance;
            multiplier = movementMultipier.Evaluate(multiplier);
        }

        yAngle = Mathf.Lerp(yAngle, inputValue.y, Time.deltaTime * 0.5f);
        xAngle = Mathf.Lerp(xAngle, inputValue.x, Time.deltaTime * 0.5f);
        moon.RotateAround(Vector3.zero, Vector3.up, xAngle * Time.deltaTime * 8f * multiplier);
        moon.RotateAround(Vector3.zero, Vector3.left, yAngle * Time.deltaTime * 8f * multiplier);
    }

    Vector3 GetPerfectEclipsePosition()
    {
        perfectEclipsePosition = (sun.position - Vector3.zero).normalized * (moon.position - Vector3.zero).magnitude;
        return perfectEclipsePosition;
    }

    void ProcessZoom()
    {

        Vector3 newPosition = (moon.position - Vector3.zero).normalized * distance * (1f / zoom);
        moon.position = Vector3.Lerp(moon.position, newPosition, Time.deltaTime * 0.75f);

        /*        newPosition = (sun.position - Vector3.zero).normalized * (distance + 120f) * (1f / zoom);
                sun.position = Vector3.Lerp(sun.position, newPosition, Time.deltaTime * 0.75f);*/
    }

    void ProcessPositionOnAmbientLight()
    {
        if (deltaPosition < triggerDistance)
        {
            float graph = deltaPosition / triggerDistance;
            ChangeAmbientColor(curve.Evaluate(graph) * zoom);
            if (isSkybox)
                ControllBloom(curve.Evaluate(graph) * zoom);
            graph = curve.Evaluate(graph) * 23f * zoom;
            if (isSkybox)
                directionalLight.rotation = Quaternion.Euler(11f - graph, 180f, 0f);
        }
    }

    void MoonAutoMovement(float input)
    {
        if (deltaPosition < 4f && input <= 0.1f)
        {
            moon.position = Vector3.Lerp(moon.position, GetPerfectEclipsePosition(), Time.deltaTime * .25f);
        }
    }

    void CalculateDeltaPosition()
    {
        deltaPosition = (moon.position - GetPerfectEclipsePosition()).magnitude;
    }

    void ChangeAmbientColor(float graph)
    {
        Color temp = new Color(normal.r - graph / 1.5f, normal.g - graph / 1.5f, normal.b - graph / 1.5f, 1f);
        RenderSettings.ambientLight = temp;
    }

    void ControllBloom(float graph)
    {
        bloomTexture.material.color = new Color(1f, 1f, 1f, graph);
    }

    public void ChangeSkyboxMode()
    {
        if (isSkybox)
        {
            directionalLight.rotation = Quaternion.Euler(11f, 180f, 0f);
            sunMaterial.material.color = new Color32(255, 255, 255, 255);
            bloomTexture.material.color = new Color(1f, 1f, 1f, 0f);
            ProcessPositionOnAmbientLight();
        }
        else
        {
            sunMaterial.material.color = new Color32(255, 255, 4, 255);
            bloomTexture.material.color = new Color(1f, 1f, 1f, 0f);
            directionalLight.rotation = Quaternion.Euler(-90f, 180f, 0f);
        }

    }
}
