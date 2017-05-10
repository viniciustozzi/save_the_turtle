using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Edge> Edges { get; set; }

    public Action<Node> _onChangeState { get; set; }

    public virtual void SetupEdges()
    {

    }

}