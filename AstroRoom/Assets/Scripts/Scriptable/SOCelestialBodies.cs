using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New list", menuName = "Extended/Celestial Bodies List")]
public class SOCelestialBodies : ScriptableObject
{
    public List<CelestialBodyController> listOfBodies;
}
