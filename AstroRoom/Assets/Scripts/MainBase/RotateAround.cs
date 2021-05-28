using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform pivot;
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivot.position, Vector3.up, Time.deltaTime * speed);
    }
}
