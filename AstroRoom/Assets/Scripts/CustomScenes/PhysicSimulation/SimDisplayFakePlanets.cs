using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimDisplayFakePlanets : MonoBehaviour
{
    public List<GameObject> planets;

    public List<float> planetsDistance;
    private List<GameObject> fakePlanets = new List<GameObject>();
    public GameObject planetPrefab;

    private void Awake()
    {
        foreach (GameObject fragment in planets)
        {
            GameObject temporary = Instantiate(planetPrefab, transform);
            temporary.name = fragment.name;
            temporary.GetComponent<Renderer>().material = fragment.GetComponent<Renderer>().material;
            fakePlanets.Add(temporary);
            Debug.Log("1");

        }
    }

    private void Update()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            Vector3 direction = (planets[i].transform.position - transform.position).normalized;
            if (i < 4)
            {
                fakePlanets[i].transform.localScale = Vector3.one * .8f;
                fakePlanets[i].transform.position = direction * planetsDistance[i];
            }
            else
            {
                fakePlanets[i].transform.localScale = Vector3.one * 2f;
                fakePlanets[i].transform.position = direction * planetsDistance[i];
            }
        }
    }

    /*    private void OnDrawGizmos()
        {
            for (int i = 0; i < planets.Count; i++)
            {
                Vector3 direction = (planets[i].transform.position - transform.position).normalized;
                if (i < 4)
                    Gizmos.DrawSphere(direction * planetsDistance[i], .4f);
                else
                    Gizmos.DrawSphere(direction * planetsDistance[i], 1f);
            }
        }*/
}
