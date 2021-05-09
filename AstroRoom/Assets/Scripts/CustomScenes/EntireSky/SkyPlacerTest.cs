using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyPlacerTest : MonoBehaviour
{
    public GameObject m_prefab;
    public int m_starsAmount = 10;
    private List<StarSettings> m_stars = new List<StarSettings>();
    public float distance = 100f;

    void Awake()
    {
        for (int i = 0; i < m_starsAmount; i++)
        {
            StartCoroutine(Randomm());
        }
    }

    // Update is called once per frame

    IEnumerator Randomm()
    {

        GameObject obj = Instantiate(m_prefab, transform);
        Vector3 randomRotation = new Vector3(UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(-179f, 20f), 0f);
        obj.transform.position = new Vector3(0f, 0f, distance);
        obj.transform.RotateAround(transform.position, Vector3.right, randomRotation.y);
        obj.transform.RotateAround(transform.position, Vector3.up, randomRotation.x);
        obj.transform.localScale = Vector3.one * UnityEngine.Random.Range(1f, 2.5f);
        yield return 0;
    }
}
[System.Serializable]
public class StarSettings
{
    public Vector3 m_position, m_rotation;
    public float m_scale;
}
