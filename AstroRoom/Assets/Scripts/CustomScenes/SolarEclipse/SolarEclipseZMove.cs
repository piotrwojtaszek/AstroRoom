using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SolarEclipseZMove : MonoBehaviour
{
    public Transform objectToMove;

    Slider slider;
    float zOrigin;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        zOrigin = objectToMove.position.z;
        Move();
    }


    // Update is called once per frame
    public void Move()
    {
        objectToMove.transform.position = new Vector3(objectToMove.transform.position.x, objectToMove.transform.position.y, zOrigin + slider.value);
    }
}
