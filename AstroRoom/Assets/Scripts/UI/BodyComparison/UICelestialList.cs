using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class UICelestialList : MonoBehaviour
{
    [SerializeField]
    private UIComparisonController comparisonController;
    [SerializeField]
    private SOCelestialBodies celestialBodiesList;
    [SerializeField]
    private Transform scrollContent;
    public GameObject listFragment;

    private void Awake()
    {
        foreach(CelestialBodyController body in celestialBodiesList.listOfBodies)
        {
            GameObject fragment = Instantiate(listFragment, scrollContent);
            fragment.GetComponent<UICelestialListFragment>().SetFragment(body,comparisonController);
        }
    }
}

