using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ConstelationController : IConstealtion
{
    public GameObject onHoverPrefab;
    private bool[,] adjMatrixCheck;
    [HideInInspector]
    public List<int> selected = new List<int>();
    public Transform persistantPosition = null;
    public UnityAction onComplete = null;
    public UnityAction onSelected = null;
    public UnityAction onReady = null;
    public GameObject hoverObject;
    public override void OnCreated(SOConstelationBase constelationPreset)
    {
        ConstelationPreset = constelationPreset;
        base.OnCreated(constelationPreset);

        transform.name = ConstelationPreset.conName;
        CreateNodesAndChild(this);
        adjMatrixCheck = new bool[ConstelationPreset.size, ConstelationPreset.size];
        CreatePersistantPositionObject();
        hoverObject.GetComponent<ConstelationFarInteractor>().OnCreate();
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

        onComplete?.Invoke();
    }

    void CreatePersistantPositionObject()
    {
        persistantPosition = new GameObject(transform.name + " HOLDER").transform;
        persistantPosition.SetParent(transform.parent.transform);
        persistantPosition.transform.position = transform.position;
        persistantPosition.transform.localScale = transform.localScale;
        persistantPosition.transform.rotation = transform.rotation;
    }
}
