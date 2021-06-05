using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SolarSystemDebugOrbitalTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(1f / GetComponent<SolarSystemOrbitController>().speed / SolarSystemController.Instance.speedMultiplier);
    }
}
