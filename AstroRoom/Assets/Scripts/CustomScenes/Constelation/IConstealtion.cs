using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IConstealtion : MonoBehaviour
{
    public SOConstelationBase ConstelationPreset { get { return constelationPreset; } set { constelationPreset = value; } }
    [SerializeField]
    private SOConstelationBase constelationPreset;
    public GameObject socketPrefab;
    public GameObject edgePrefab;
    protected bool[,] adjMatrix { get; set; }
    public Transform[] nodes { get; protected set; }

    public virtual void OnCreated(SOConstelationBase constelationPreset)
    {
        CopyMatrix();
    }

    protected void CreateConnection(int id_1, int id_2, ConstelationController controller)
    {
        GameObject lineObj = Instantiate(edgePrefab, transform);
        ConstelationEdge lineControler = lineObj.GetComponent<ConstelationEdge>();
        lineControler.constelationController = controller;
        lineControler.id_1 = id_1;
        lineControler.id_2 = id_2;
    }

    protected bool VerifyConnection(int id_1, int id_2)
    {
        return adjMatrix[id_1, id_2];
    }

    protected void CopyMatrix()
    {
        adjMatrix = new bool[ConstelationPreset.size, ConstelationPreset.size];
        for (int x = 0; x < ConstelationPreset.size; x++)
        {
            for (int y = 0; y < ConstelationPreset.size; y++)
            {
                adjMatrix[x, y] = ConstelationPreset.adjMatrix[x * ConstelationPreset.size + y];

            }
        }
    }


    protected void CreateNodes()
    {
        nodes = new Transform[ConstelationPreset.size];
        int i = 0;
        foreach (Node node in ConstelationPreset.nodes)
        {
            GameObject nodeObj = Instantiate(socketPrefab, transform);
            nodeObj.transform.localPosition = node.position;
            nodeObj.transform.localScale = Vector3.one * node.size;
            nodeObj.GetComponent<INode>().id = i;
            nodes[i] = nodeObj.transform;
            i++;
        }
    }

    protected void CreateNodesAndChild(ConstelationController controller)
    {
        nodes = new Transform[ConstelationPreset.size];
        int i = 0;
        transform.localPosition = transform.localPosition + new Vector3(0, 0, 50f);
        foreach (Node node in ConstelationPreset.nodes)
        {
            GameObject nodeObj = Instantiate(socketPrefab, transform);
            nodeObj.GetComponent<ConstelationSocket>().constelationController = controller;
            nodeObj.transform.localPosition = node.position;
            nodeObj.transform.localScale = Vector3.one * node.size;
            nodeObj.GetComponent<INode>().id = i;
            nodes[i] = nodeObj.transform;
            i++;
        }
        transform.localScale = Vector3.one * 4f;
        gameObject.transform.RotateAround(Vector3.zero, Vector3.up, ConstelationPreset.skyPosition.y);
        gameObject.transform.RotateAround(Vector3.zero, Vector3.left, ConstelationPreset.skyPosition.x);
        
    }
}
