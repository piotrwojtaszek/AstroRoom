using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstelationController : MonoBehaviour
{
    public SOConstelationBase constelationPreset = null;
    [HideInInspector]
    public List<GameObject> helpers = new List<GameObject>();
}
