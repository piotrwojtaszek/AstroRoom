using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstelationSkyDisplay : IConstealtion
{
    protected override void Awake()
    {
        CopyMatrix();
        GameObject parent = CreateNodesAndChild();
    }

}
