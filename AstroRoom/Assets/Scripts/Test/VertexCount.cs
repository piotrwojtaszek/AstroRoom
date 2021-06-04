using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexCount : MonoBehaviour
{
    Mesh mesh;
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;

    }

    private void Update()
    {
        print(mesh.triangles.Length);
    }
}
