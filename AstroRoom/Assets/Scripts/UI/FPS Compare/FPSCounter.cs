using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FPSCounter : MonoBehaviour
{

    public TextMeshProUGUI counter;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FpsCounterUpdate());
    }

    // Update is called once per frame
    IEnumerator FpsCounterUpdate()
    {
        int i = 0;
        float sum = 0;
        int number = 0;
        for (; ; )
        {
            i++;
            sum += (1f / Time.unscaledDeltaTime);
            if (i % 100 == 0)
            {
                counter.text = "FPS: " + (sum / i).ToString("F2");
                sum = 0;
                i = 0;
                number++;
            }
            yield return null;
        }

    }
}
