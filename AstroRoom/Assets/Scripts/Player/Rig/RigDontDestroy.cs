using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigDontDestroy : MonoBehaviour
{
    public static RigDontDestroy Instance;
    private void Awake()
    {
        if (Instance != this && Instance!=null)
            Destroy(gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(gameObject);
    }
}
