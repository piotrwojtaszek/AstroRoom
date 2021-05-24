using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIComparisonController : MonoBehaviour
{
    public UICelestialList celestialList;
    public Transform celestialBodyOrigin;
    [Tooltip("+ right ... - left")]
    public int side = 1;

    public void OnClicked(CelestialBodyController bodyPrefab)
    {
        foreach (Transform child in celestialBodyOrigin)
        {
            Destroy(child.gameObject);
        }

        GameObject obj = Instantiate(bodyPrefab.properties.GraphicPrefab, celestialBodyOrigin);

        obj.layer = LayerMask.NameToLayer("SolarSystemPlanets");
        obj.AddComponent<SphereCollider>();
        obj.transform.localScale = Vector3.one * bodyPrefab.properties.Size;
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
        obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, bodyPrefab.properties.Size/1.5f);
        Invoke("Compare", .01f);
        MoveInX(bodyPrefab);
    }

    void Compare()
    {
        ComputeDistance.Instance.Compare();
    }
    void MoveInX(CelestialBodyController bodyPrefab)
    {
        /*        transform.position = new Vector3(-GetPlanetSize() * side, transform.position.y, transform.position.z);*/
        transform.GetChild(0).position = new Vector3(2f * side, transform.GetChild(0).position.y, transform.GetChild(0).position.z);
        transform.GetChild(1).position = new Vector3(bodyPrefab.properties.Size / 1.8f * side, bodyPrefab.properties.Size/2f, transform.GetChild(0).position.z);

    }
}
