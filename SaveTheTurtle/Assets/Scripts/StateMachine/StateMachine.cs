using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine
{
    private List<Node> states;
    private Node currentState;

    public StateMachine()
    {
        states = new List<Node>();
    }

    public void AddState(Node state)
    {
        if (states.Count == 0)
            currentState = state;

        states.Add(state);
    }

    public void AddState(Node state, List<Edge> edges)
    {
        state.AddEdges(edges);

        if (states.Count == 0)
            currentState = state;

        states.Add(state);
    }

    public void OnChangeState(Transition t)
    {
        currentState.enabled = false;
        currentState = currentState.Edges.FirstOrDefault(x => x.Transition == t).To;
        currentState.enabled = true;
    }
}
