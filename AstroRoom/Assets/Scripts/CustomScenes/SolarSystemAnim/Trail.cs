using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    TrailRenderer trailRenderer;
    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        trailRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
