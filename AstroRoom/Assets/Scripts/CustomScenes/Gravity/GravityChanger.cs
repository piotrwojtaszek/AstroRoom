using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public LayerMask gravityObjectMask;
    public float gravity;
    public Color gravityColor;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = gravityColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == gravityObjectMask)
        {
            other.gameObject.GetComponent<ArtificialGravity>().gravity = gravity;
            other.gameObject.GetComponent<Renderer>().material.color = gravityColor;
        }
    }
}
