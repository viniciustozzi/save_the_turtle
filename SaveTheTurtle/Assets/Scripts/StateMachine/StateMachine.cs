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
        Edge edgeToNextState = currentState.Edges.FirstOrDefault(x => x.Transition == t);

        if (edgeToNextState == null)
            return;

        currentState.enabled = false;
        currentState = edgeToNextState.To;
        currentState.enabled = true;
    }
}
