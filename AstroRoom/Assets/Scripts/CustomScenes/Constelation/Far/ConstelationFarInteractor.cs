using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ConstelationFarInteractor : MonoBehaviour
{
    public ConstelationController constelationController;
    public GameObject constelationName;
    private void Start()
    {
        ConstelationEvents.Instance.onSelected += DisableCollider;
        ConstelationEvents.Instance.onSkyPosition += EnableCollider;
    }
    public void OnCreate()
    {
        Bounds bounds = GetCenterPoint();
        transform.localPosition = constelationController.ConstelationPreset.boundCenter;
        transform.localScale = new Vector3(constelationController.ConstelationPreset.boundSize.x, constelationController.ConstelationPreset.boundSize.y, 1f);
        constelationName.GetComponent<TextMeshPro>().text = constelationController.ConstelationPreset.conName;
        constelationName.transform.localPosition = constelationController.ConstelationPreset.titleHeight;
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

    public void EnableCollider()
    {
        GetComponent<Collider>().enabled = true;
    }

    public void DisableCollider()
    {
        GetComponent<Collider>().enabled = false;
    }
}
