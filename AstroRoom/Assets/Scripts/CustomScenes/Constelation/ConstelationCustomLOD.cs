using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ConstelationCustomLOD : MonoBehaviour
{
    CustomLOD currentLOD = CustomLOD.Close;
    public UnityAction onCloseLOD;
    public UnityAction onFarLOD;

    // Update is called once per frame
    void Update()
    {
        if ((Camera.main.transform.position - transform.position).magnitude > 20f && currentLOD == CustomLOD.Close)
        {
            currentLOD = CustomLOD.Far;
            onFarLOD?.Invoke();
            return;
        }
        if ((Camera.main.transform.position - transform.position).magnitude <= 20f && currentLOD == CustomLOD.Far)
        {
            currentLOD = CustomLOD.Close;
            onCloseLOD?.Invoke();
            return;
        }
    }
}

public enum CustomLOD
{
    Close,
    Far
}
