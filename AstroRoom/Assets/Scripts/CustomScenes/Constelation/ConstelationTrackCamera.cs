using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstelationTrackCamera : MonoBehaviour
{
    public Camera mainCam;

    private void Update()
    {
        transform.position = new Vector3(mainCam.transform.position.x, transform.position.y, mainCam.transform.position.z);
    }
}
