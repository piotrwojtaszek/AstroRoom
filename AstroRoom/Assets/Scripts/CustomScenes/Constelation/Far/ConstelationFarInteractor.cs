using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
public class ConstelationFarInteractor : MonoBehaviour
{
    public ConstelationController constelationController;

    private void Start()
    {
        constelationController.onSkyPosition += OnSkyPosition;
        constelationController.onSelected += OnSelected;
    }
    public void OnCreate()
    {
        Bounds bounds = GetCenterPoint();
        transform.position = bounds.center;
        transform.localScale = new Vector3(bounds.size.x / 2f, bounds.size.y / 2f,1f);


        //Debug.Log(transform.lossyScale);
    }


    Bounds GetCenterPoint()
    {
        List<Transform> objectsToEncaplsulate = new List<Transform>();
        foreach (Transform child in constelationController.transform)
        {
            if (child.GetComponent<ConstelationSocket>() != null)
            {
                objectsToEncaplsulate.Add(child);
            }
        }

        var bounds = new Bounds(objectsToEncaplsulate[0].position, Vector3.zero);
        for (int i = 0; i < objectsToEncaplsulate.Count; i++)
        {
            bounds.Encapsulate(objectsToEncaplsulate[i].position);
        }
        return bounds;
    }

    public void OnSkyPosition()
    {
        GetComponent<Collider>().enabled = true;
    }

    public void OnSelected()
    {
        GetComponent<Collider>().enabled = false;
    }
}
