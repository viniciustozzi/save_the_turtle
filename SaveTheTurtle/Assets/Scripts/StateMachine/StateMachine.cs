using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private List<Node> states;

    public void AddState(Node state)
    {
        states.Add(state);
    }
}
