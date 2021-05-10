using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyPlacerTest : MonoBehaviour
{
    public GameObject m_prefab;
    public int m_starsAmount = 10;
    private List<StarSettings> m_stars = new List<StarSettings>();
    public float distance = 100f;

    private float y;
    private float z;
    private bool rotateX;
    [SerializeField]
    private float rotationSpeed;
    public bool isReady = false;
    public float yAmount;
    public float xAmount;

    void Awake()
    {
        for (int i = 0; i < m_starsAmount; i++)
        {
            StartCoroutine(Randomm());
        }
        transform.localRotation = Quaternion.Euler(89f, 0f, 0f);
    }

    private void Update()
    {

        if (isReady == false)
            return;
        y += Time.deltaTime * rotationSpeed;

        if (y > 360.0f)
        {
            y = 0.0f;
        }


        /*transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x+y, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);*/
        /*        transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotationSpeed);
                transform.rotation += Quaternion.Euler(89f, 0f, 0f);*/
        transform.Rotate(0, yAmount, 0, Space.Self);
        transform.Rotate(xAmount, 0, 0, Space.World);
    }

    // Update is called once per frame

    IEnumerator Randomm()
    {

        GameObject obj = Instantiate(m_prefab, transform);
        Vector3 randomRotation = new Vector3(UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(-178f, 178f), 0f);
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
