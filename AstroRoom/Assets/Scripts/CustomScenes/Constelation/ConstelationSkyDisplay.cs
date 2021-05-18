using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstelationSkyDisplay : MonoBehaviour
{
    public SOConstelationList constelationList;
    public GameObject constelationControllerPrefab;
    void Awake()
    {
        foreach(SOConstelationBase fragment in constelationList.listOfBodies)
        {
            GameObject newObject = Instantiate(constelationControllerPrefab, transform);
            newObject.GetComponent<ConstelationController>().OnCreated(fragment);
        }
    }

}
