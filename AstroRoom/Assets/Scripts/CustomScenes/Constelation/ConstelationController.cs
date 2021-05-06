using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ConstelationController : MonoBehaviour
{
    public static ConstelationController instance;
    public SOConstelationBase ConstelationPreset { get { return constelationPreset; } }
    [SerializeField]
    private SOConstelationBase constelationPreset;
    public GameObject socket;
    public GameObject edge;
    public bool[,] adjMatrix;
    public bool[,] adjMatrixCheck;
    public Transform[] nodes;
    public List<int> selected = new List<int>();
    private void Awake()
    {
        instance = this;
        string temp = "";
        adjMatrix = new bool[ConstelationPreset.size, ConstelationPreset.size];
        adjMatrixCheck = new bool[ConstelationPreset.size, ConstelationPreset.size];
        for (int x = 0; x < ConstelationPreset.size; x++)
        {
            for (int y = 0; y < ConstelationPreset.size; y++)
            {
                adjMatrix[x, y] = ConstelationPreset.adjMatrix[x * ConstelationPreset.size + y];
                if (adjMatrix[x, y])
                {
                    temp += "1 ";
                }
                else
                {
                    temp += "0 ";
                }
                if (x == y)
                {
                    temp += "- ";
                }
            }
            temp += "\n";
        }
        Debug.Log(temp);
        nodes = new Transform[ConstelationPreset.size];
        int i = 0;
        foreach (Node node in ConstelationPreset.nodes)
        {
            GameObject nodeObj = Instantiate(socket, transform);
            nodeObj.transform.localPosition = node.position;
            nodeObj.GetComponent<ConstelationSocket>().id = i;
            nodes[i] = nodeObj.transform;
            i++;
        }
    }

    public void CheckConnection()
    {
        if (selected.Count == 2)
        {
            if (adjMatrix[selected[0], selected[1]] == true && adjMatrixCheck[selected[0], selected[1]] == false)
            {
                adjMatrixCheck[selected[0], selected[1]] = true;
                adjMatrixCheck[selected[1], selected[0]] = true;
                GameObject lineObj = Instantiate(edge, transform);
                ConstelationEdge lineControler = lineObj.GetComponent<ConstelationEdge>();
                lineControler.id_1 = selected[0];
                lineControler.id_2 = selected[1];
            }
            selected.Clear();
        }
    }
}
