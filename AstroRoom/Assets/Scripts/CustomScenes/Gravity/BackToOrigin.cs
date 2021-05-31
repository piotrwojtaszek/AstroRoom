using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToOrigin : MonoBehaviour
{
    Vector3 origin;
    private void Awake()
    {
        origin = transform.position;    
    }


    private void Update()
    {
        if(transform.position.y < -10f)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.position = origin;
            transform.rotation = Quaternion.Euler(0, 0f, 0f);
        }
    }

}
