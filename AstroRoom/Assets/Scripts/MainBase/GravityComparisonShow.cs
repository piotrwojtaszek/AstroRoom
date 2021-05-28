using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityComparisonShow : MonoBehaviour
{
    public Transform object_1;
    public Transform object_2;
    public GameObject top;
    Vector3 origin_1;
    Vector3 origin_2;
    // Start is called before the first frame update
    void Start()
    {
        origin_1 = object_1.position;
        origin_2 = object_2.position;
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(3f);
            top.SetActive(false);


            yield return new WaitForSeconds(6f);
            top.SetActive(true);
            object_1.position = origin_1;
            object_2.position = origin_2;
        }
    }


}
