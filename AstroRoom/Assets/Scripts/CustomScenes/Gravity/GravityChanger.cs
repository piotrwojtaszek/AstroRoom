using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GravityChanger : MonoBehaviour
{
    public float gravity;
    public Color gravityColor;
    public string planetName;

    public TextMeshProUGUI upperText;
    public TextMeshProUGUI bottomText;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = gravityColor;
        upperText.text = gravity.ToString() + " m/s²";
        bottomText.text = planetName;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("GravityObject"))
        {
            other.gameObject.GetComponent<ArtificialGravity>().gravity = gravity;
            other.gameObject.GetComponent<Renderer>().material.color = gravityColor;
        }
    }
}
