using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimDisplayFakePlanets : MonoBehaviour
{
    public List<GameObject> planets;

    public List<float> planetsDistance;
    private List<GameObject> fakePlanets = new List<GameObject>();
    public GameObject planetPrefab;
    public float sizeSmall = .8f;
    public float sizeBig = 2f;
    public float sizeMultiplier = 1f;
    public bool trail = true;
    public float height = 0f;
    private void Awake()
    {
        foreach (GameObject fragment in planets)
        {
            GameObject temporary = Instantiate(planetPrefab, transform);
            temporary.name = fragment.name;
            temporary.GetComponent<Renderer>().material = fragment.GetComponent<Renderer>().material;
            temporary.GetComponent<MatchFakeShadow>().lightSource = fragment.GetComponent<MatchFakeShadow>().lightSource;
            fakePlanets.Add(temporary);
        }

        SimControllerEvents.Instance.onChangeMode += ChangeMode;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            Vector3 direction = (planets[i].transform.position - transform.position).normalized;
            if (i < 4)
            {
                fakePlanets[i].transform.localScale = Vector3.one * sizeSmall * sizeMultiplier;
                fakePlanets[i].transform.position = direction * planetsDistance[i] + Vector3.up * height;
            }
            else
            {
                fakePlanets[i].transform.localScale = Vector3.one * sizeBig * sizeMultiplier;
                fakePlanets[i].transform.position = direction * planetsDistance[i] + Vector3.up * height;
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
    void ChangeMode()
    {
        foreach (GameObject fragment in fakePlanets)
        {
            fragment.GetComponent<Renderer>().enabled = !fragment.GetComponent<Renderer>().enabled;
            fragment.GetComponent<Collider>().enabled = !fragment.GetComponent<Collider>().enabled;
            fragment.GetComponent<TrailRenderer>().Clear();
            fragment.GetComponent<TrailRenderer>().enabled = !fragment.GetComponent<TrailRenderer>().enabled;
            if (trail == false)
            {
                fragment.GetComponent<TrailRenderer>().enabled = false;
            }
        }

        foreach (GameObject fragment in planets)
        {
            fragment.GetComponent<Renderer>().enabled = !fragment.GetComponent<Renderer>().enabled;
            fragment.GetComponent<Collider>().enabled = !fragment.GetComponent<Collider>().enabled;
            fragment.GetComponent<TrailRenderer>().Clear();
            fragment.GetComponent<TrailRenderer>().enabled = !fragment.GetComponent<TrailRenderer>().enabled;

        }
    }
}
