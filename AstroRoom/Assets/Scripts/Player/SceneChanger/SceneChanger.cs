using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class SceneChanger : MonoBehaviour
{

    public enum ScenesName
    {
        Tutorial = 0,
        MainBase = 1,
        Constelations = 2,
        SolarSystemSim = 3,
        SolarSystemAnim = 4,
        SolarEclipse = 5,
        Gravity = 6
    }

    public ScenesName scenesName = ScenesName.MainBase;
    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync((int)scenesName);
    }
}
