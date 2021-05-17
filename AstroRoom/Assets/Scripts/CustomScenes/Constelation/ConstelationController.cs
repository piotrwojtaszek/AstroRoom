using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ConstelationController : IConstealtion
{
    public static ConstelationController instance;
    private bool[,] adjMatrixCheck;
    public List<int> selected = new List<int>();
    protected override void Awake()
    {
        base.Awake();
        CreateNodes();
        instance = this;
        adjMatrixCheck = new bool[ConstelationPreset.size, ConstelationPreset.size];
    }

    public void CheckConnection()
    {
        if (selected.Count == 2)
        {
            if (VerifyConnection(selected[0], selected[1]))
                if (adjMatrixCheck[selected[0], selected[1]] == false)
                {
                    adjMatrixCheck[selected[0], selected[1]] = true;
                    adjMatrixCheck[selected[1], selected[0]] = true;
                    CreateConnection(selected[0], selected[1]);
                    selected.Clear();
                }
        }
        CheckIfCompleted();
    }

    public void CheckIfCompleted()
    {
        for (int i = 0; i < ConstelationPreset.size; i++)
            for (int j = 0; j < ConstelationPreset.size; j++)
            {
                if (ConstelationPreset.adjMatrix[ConstelationPreset.size * i + j] != adjMatrixCheck[i, j])
                    return;
            }

        StartCoroutine(BackToSky());
        Debug.Log("COMPLETED");
    }

    IEnumerator BackToSky()
    {
        Transform finded = FindObjectOfType<ConstelationFarInteractor>().transform;

        for (; ; )
        {
            transform.position = Vector3.Lerp(transform.position, finded.position, Time.deltaTime * .2f);
            if ((transform.position - finded.position).magnitude < 2f)
            {
                break;
            }
            yield return null;
        }

        Destroy(gameObject);

        yield return null;
    }
}
