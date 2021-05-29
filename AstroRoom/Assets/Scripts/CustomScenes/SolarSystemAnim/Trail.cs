using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    TrailRenderer trailRenderer;
    SolarSystemOrbitController systemOrbitController;
    float originalVertexDist;
    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        systemOrbitController = GetComponent<SolarSystemOrbitController>();
        originalVertexDist = trailRenderer.minVertexDistance;
        SolarSystemController.Instance.onSizeChange += ResetTrail;

    }
    // Start is called before the first frame update
    void Start()
    {
        trailRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        trailRenderer.minVertexDistance = originalVertexDist * SolarSystemController.Instance.sizeMultiplier;
        trailRenderer.widthMultiplier = SolarSystemController.Instance.sizeMultiplier;
        trailRenderer.time = 1f / systemOrbitController.speed / SolarSystemController.Instance.speedMultiplier;
    }

    public void ResetTrail() => trailRenderer.Clear();
}
