using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ConstelationController : IConstealtion
{
    public GameObject onHoverPrefab;
    private bool[,] adjMatrixCheck;
    [HideInInspector]
    public List<int> selected = new List<int>();
    public override void OnCreated(SOConstelationBase constelationPreset)
    {
        ConstelationPreset = constelationPreset;
        base.OnCreated(constelationPreset);

        transform.name = ConstelationPreset.conName;
        CreateNodesAndChild(this);
        adjMatrixCheck = new bool[ConstelationPreset.size, ConstelationPreset.size];
        CreateOnHoverEffect();
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
                    CreateConnection(selected[0], selected[1], this);
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

        /*StartCoroutine(BackToSky());*/
    }

    /*    IEnumerator BackToSky()
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
        }*/
    private void CreateOnHoverEffect()
    {
        Instantiate(onHoverPrefab, transform);
    }
}
