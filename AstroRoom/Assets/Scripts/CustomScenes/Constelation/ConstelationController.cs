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
    private Transform persistantPosition = null;
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

        StartCoroutine(BackToSky());
    }

    IEnumerator BackToSky()
    {
        for (; ; )
        {
            transform.position = Vector3.Lerp(transform.position, persistantPosition.position, Time.deltaTime * .5f);
            transform.localScale = Vector3.Lerp(transform.localScale, persistantPosition.localScale, Time.deltaTime * .51f);
            transform.rotation = Quaternion.Lerp(transform.rotation, persistantPosition.rotation, Time.deltaTime * .5f);
            if ((transform.position - persistantPosition.position).magnitude < 0.01f)
            {
                break;
            }
            yield return null;
        }
        Destroy(persistantPosition.gameObject);
        persistantPosition = null;
        yield return null;
    }
    private void CreateOnHoverEffect()
    {
        GameObject hoverObj = Instantiate(onHoverPrefab, transform);
        hoverObj.GetComponent<ConstelationSkyTOPlayer>().onSelected += OnSelected;
    }

    private void OnSelected()
    {
        persistantPosition = new GameObject(transform.name + " HOLDER").transform;
        persistantPosition.SetParent(transform.parent);
        persistantPosition.transform.position = transform.position;
        persistantPosition.transform.localScale = transform.localScale;
        persistantPosition.transform.rotation = transform.rotation;
    }
}
