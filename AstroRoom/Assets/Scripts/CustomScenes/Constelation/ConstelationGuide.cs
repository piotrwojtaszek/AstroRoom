using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConstelationGuide : MonoBehaviour
{
    public GameObject image;

    private void Start()
    {
        ConstelationEvents.Instance.onSelected += OnSelected;
        ConstelationEvents.Instance.onComplete += OnComplete;
    }

    public void OnSelected()
    {
        image.SetActive(true);
        image.GetComponent<Image>().sprite = ConstelationEvents.Instance.currentSelected?.Invoke();
    }
    public void OnComplete()
    {
        image.SetActive(false);
    }
}
