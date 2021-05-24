using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ComputeDistance : MonoBehaviour
{
    public static ComputeDistance Instance;
    public Transform origin_1;
    public Transform origin_2;
    private void Awake()
    {
        Instance = this;
    }

    public void Compare()
    {
        if (origin_1.childCount == 0 || origin_2.childCount == 0)
            return;

        Debug.Log("Sprawdzam: " + origin_1.GetChild(0).transform.lossyScale + "     Drugie: " + origin_2.GetChild(0).transform.lossyScale);
        if (origin_1.GetChild(0).transform.lossyScale.x >= origin_2.GetChild(0).transform.lossyScale.x)
        {
            origin_1.GetChild(0).transform.localPosition = new Vector3(0, 0, origin_1.GetChild(0).transform.lossyScale.x / 1.5f);
            origin_2.GetChild(0).transform.localPosition = new Vector3(0, 0, origin_1.GetChild(0).transform.lossyScale.x / 1.5f);
        }
        if (origin_1.GetChild(0).transform.lossyScale.x < origin_2.GetChild(0).transform.lossyScale.x)
        {
            origin_2.GetChild(0).transform.localPosition = new Vector3(0, 0, origin_2.GetChild(0).transform.lossyScale.x / 1.5f);
            origin_1.GetChild(0).transform.localPosition = new Vector3(0, 0, origin_2.GetChild(0).transform.lossyScale.x / 1.5f);
        }
    }
}
