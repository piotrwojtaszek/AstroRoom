using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    private void Start()
    {
        ConstelationEvents.Instance.onProgressReset += OnProgressReset;
    }

    public void ResetProgress() => ConstelationEvents.Instance.onProgressReset?.Invoke();

    void OnProgressReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
