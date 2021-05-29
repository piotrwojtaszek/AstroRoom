using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class SceneChanger : MonoBehaviour
{

    public enum ScenesName
    {
        MainBase = 0,
        Constelations = 1,
        SolarSystemSim = 2,
        SolarSystemAnim = 3,
        SolarEclipse = 4,
        Gravity = 5
    }

    public ScenesName scenesName = ScenesName.MainBase;
    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync((int)scenesName);
    }
}
