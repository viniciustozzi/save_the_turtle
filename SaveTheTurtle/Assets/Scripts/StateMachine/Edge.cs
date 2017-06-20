using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    public Node From { get; set; }
    public Node To { get; set; }

    public Transition Transition { get; set; }

    public Edge(Node from, Node to)
    {
        this.From = from;
        this.To = to;
    }

    public Edge(Node from, Transition transition, Node to)
    {
        this.From = from;
        this.Transition = transition;
        this.To = to;
    }

    public Edge(Transition transition, Node to)
    {
        this.Transition = transition;
        this.To = to;
    }
}
