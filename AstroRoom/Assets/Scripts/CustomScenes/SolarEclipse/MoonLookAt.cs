using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonLookAt : MonoBehaviour
{
    public Transform lokAt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(lokAt.position.x, lokAt.position.y, 1500f));
    }
}
