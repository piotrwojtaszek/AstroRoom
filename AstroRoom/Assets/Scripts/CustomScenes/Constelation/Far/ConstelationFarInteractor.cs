using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
public class ConstelationFarInteractor : MonoBehaviour
{
    public GameObject quad;
    public List<Transform> targets = new List<Transform>();
    // Start is called before the first frame update
    private void Start()
    {
        if (transform.childCount == 0)
            return;

        foreach (Transform child in transform)
        {
            targets.Add(child);
        }
        if (targets.Count == 0)
            return;

        Bounds bounds = GetCenterPoint();


        GameObject createdQuad = Instantiate(quad, transform);
        createdQuad.transform.position = bounds.center;
        createdQuad.transform.localScale = new Vector3(bounds.size.x / 2f, bounds.size.y / 2f, bounds.size.z / 2f);
    }

    void LateUpdate()
    {



    }

    Bounds GetCenterPoint()
    {
        if (targets.Count == 1)
            return new Bounds(Vector3.zero, Vector3.zero);
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds;
    }

}
