using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
public class ConstelationFarInteractor : MonoBehaviour
{
    private void Start()
    {
        OnCreate();
    }
    public void OnCreate()
    {
        Bounds bounds = GetCenterPoint();
        transform.position = bounds.center;
        transform.localScale = new Vector3(bounds.size.x / 2f, bounds.size.y / 2f, bounds.size.z / 2f);
    }


    Bounds GetCenterPoint()
    {
        List<Transform> objectsToEncaplsulate = new List<Transform>();
        foreach (Transform child in transform.parent)
        {
            if (child.GetComponent<ConstelationSocket>() != null)
            {
                objectsToEncaplsulate.Add(child);
            }
        }

        var bounds = new Bounds(Vector3.zero, Vector3.zero);
        for (int i = 0; i < objectsToEncaplsulate.Count; i++)
        {
            bounds.Encapsulate(objectsToEncaplsulate[i].position);
        }
        return bounds;
    }
}
