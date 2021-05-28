using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UICelestialListFragment : MonoBehaviour
{
    private CelestialBodyController celestialProperties;
    private UIComparisonController comparisonController;
    public TextMeshProUGUI nameField;

    // Start is called before the first frame update
    void Start()
    {
        nameField.text = celestialProperties.properties.Name;
    }

    public void OnClick()
    {
        comparisonController.OnClicked(celestialProperties);
    }


    public void SetFragment(CelestialBodyController bodyProperties, UIComparisonController controller)
    {
        celestialProperties = bodyProperties;
        comparisonController = controller;
    }
}
