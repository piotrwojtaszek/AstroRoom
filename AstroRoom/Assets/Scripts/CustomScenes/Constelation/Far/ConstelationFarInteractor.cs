using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using TMPro;
public class ConstelationFarInteractor : MonoBehaviour
{
    public ConstelationController constelationController;
    public GameObject constelationName;
    private void Start()
    {
        /*        constelationController.onSkyPosition += OnSkyPosition;
                constelationController.onSelected += OnSelected;*/

        ConstelationEvents.Instance.onSelected += DisableCollider;
        ConstelationEvents.Instance.onSkyPosition += EnableCollider;


    }
    public void OnCreate()
    {
        StartCoroutine(Create());

        //Debug.Log(transform.lossyScale);
    }
    IEnumerator Create()
    {
        yield return new WaitForSeconds(1f);
        Bounds bounds = GetCenterPoint();
        transform.position = bounds.center;
        transform.localScale = new Vector3(bounds.extents.x, bounds.size.y / 2f, 1f);
        constelationName.GetComponent<TextMeshPro>().text = constelationController.ConstelationPreset.conName;
        constelationName.transform.localPosition = new Vector3(0f, bounds.extents.y, 0f);
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

        var bounds = new Bounds(transform.position, Vector3.zero);
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

    private void OnDrawGizmos()
    {
        var bounds = GetCenterPoint();
        Gizmos.DrawCube(bounds.center, new Vector3(bounds.extents.x, bounds.extents.y, 1f));
    }
}
