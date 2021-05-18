using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New list", menuName = "Extended/Constelations List")]
public class SOConstelationList : ScriptableObject
{
    public List<SOConstelationBase> listOfBodies;
}
