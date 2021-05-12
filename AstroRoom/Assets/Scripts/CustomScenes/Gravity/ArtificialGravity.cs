using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ArtificialGravity : MonoBehaviour
{
    public float gravity = 3f;
    private float calculatedGravity = 9.81f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        calculatedGravity = 9.81f - gravity;
        rb.AddForce(Vector3.up * calculatedGravity * rb.mass);
    }
}
