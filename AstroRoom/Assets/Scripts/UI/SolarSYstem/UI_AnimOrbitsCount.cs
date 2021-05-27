using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_AnimOrbitsCount : MonoBehaviour
{

    public List<IOrbitsCount> orbitControllers;
    public GameObject panelrefab;
    // Start is called before the first frame update
    void Start()
    {
        foreach(IOrbitsCount fragment in orbitControllers)
        {
            GameObject createdFragment =  Instantiate(panelrefab, transform);
            createdFragment.GetComponent<UI_AnimOrbitsCountFragment>().orbitCounter = fragment;
            createdFragment.GetComponent<UI_AnimOrbitsCountFragment>().planeName.text = fragment.gameObject.name;
        }
    }
}
