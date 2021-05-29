using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIComparisonController : MonoBehaviour
{
    public UICelestialList celestialList;
    public Transform celestialBodyOrigin;
    [Tooltip("+ right ... - left")]
    public int side = 1;
    Vector3 originPosition;
    public GameObject comparisonBodyPrefab;
    private void Start()
    {
        originPosition = transform.GetChild(1).localPosition;
    }
    public void OnClicked(CelestialBodyController bodyPrefab)
    {
        foreach (Transform child in celestialBodyOrigin)
        {
            Destroy(child.gameObject);
        }

        GameObject obj = Instantiate(comparisonBodyPrefab, celestialBodyOrigin);
        obj.GetComponent<Renderer>().sharedMaterial = bodyPrefab.properties.GraphicPrefab.GetComponent<Renderer>().sharedMaterial;
        obj.layer = LayerMask.NameToLayer("SolarSystemPlanets");
        obj.AddComponent<SphereCollider>();
        obj.transform.localScale = Vector3.one * bodyPrefab.properties.Size;
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
        obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y, bodyPrefab.properties.Size / 1.5f);
        Invoke("Compare", .01f);
        MoveInX(bodyPrefab);
        StartCoroutine(EnableRenderer(obj));
    }

    void Compare()
    {
        ComputeDistance.Instance.Compare();
    }
    void MoveInX(CelestialBodyController bodyPrefab)
    {
        /*        transform.position = new Vector3(-GetPlanetSize() * side, transform.position.y, transform.position.z);*/
        //transform.GetChild(0).localPosition = new Vector3(side, transform.GetChild(0).localPosition.y, transform.GetChild(0).localPosition.z);
        transform.GetChild(1).localPosition = new Vector3(originPosition.x + bodyPrefab.properties.Size / 1.95f * side, bodyPrefab.properties.Size / 2f, transform.GetChild(0).localPosition.z);

    }

    IEnumerator EnableRenderer(GameObject obj)
    {
        yield return new WaitForSeconds(.03f);
        obj.GetComponent<MeshRenderer>().enabled = true;

    }
}
