using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_AnimOrbitsCountFragment : MonoBehaviour
{
    public IOrbitsCount orbitCounter;
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI planeName;

    private void Update()
    {
        counterText.text = orbitCounter.orbitsCount.ToString();
    }
}
