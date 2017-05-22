using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Edge> Edges { get; set; }
    public Action<Transition> _onChangeState { get; set; }

    private void Awake()
    {
        Edges = new List<Edge>();
    }

    public void AddEdge(Edge e)
    {
        Edges.Add(e);
    }

    public void AddEdges(List<Edge> edges)
    {
        Edges.AddRange(edges);
    }

    public void AddEdge(Node from, Node to)
    {
        Edges.Add(new Edge(from, to));
    }

    public void AddEdge(Node from, Transition transition, Node to)
    {
        Edges.Add(new Edge(from, transition, to));
    }

}