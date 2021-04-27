using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchFakeShadow : MonoBehaviour
{
    public Transform lightSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(lightSource);
    }
}
