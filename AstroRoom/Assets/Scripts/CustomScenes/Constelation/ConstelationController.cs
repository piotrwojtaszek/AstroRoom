using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ConstelationController : MonoBehaviour
{
    public static ConstelationController instance;
    public SOConstelationBase constelationPreset;
    public GameObject socket;
    public GameObject edge;
    public bool[,] adjMatrix;
    public Transform[] nodes;
    public List<int> selected = new List<int>();
    private void Awake()
    {
        instance = this;
        string temp = "";
        adjMatrix = new bool[constelationPreset.size, constelationPreset.size];
        for (int x = 0; x < constelationPreset.size; x++)
        {
            for (int y = 0; y < constelationPreset.size; y++)
            {
                adjMatrix[x, y] = constelationPreset.adjMatrix[x * constelationPreset.size + y];
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

        int i = 0;
        foreach (Node node in constelationPreset.nodes)
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
            if (adjMatrix[selected[0], selected[1]] == true)
            {
                GameObject lineObj = Instantiate(edge, transform);
                ConstelationEdge lineControler = lineObj.GetComponent<ConstelationEdge>();
                lineControler.id_1 = selected[0];
                lineControler.id_2 = selected[1];
                selected.Clear();
            }
    }


}
