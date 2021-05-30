using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstelationComplete : MonoBehaviour
{

    public GameObject button;
    public GameObject outline;
    public void Start()
    {
        ConstelationEvents.Instance.onAlmostComplete += EnableRenderer;
    }

    public void EnableRenderer()
    {
        button.SetActive(true);
    }

    public void CompleteConstelation()
    {
        ConstelationEvents.Instance.onComplete?.Invoke();
        button.SetActive(false);
        outline.SetActive(false);
    }
}
