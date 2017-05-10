using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MoveState))]
public class TurtleBehaviour : MonoBehaviour
{

    private StateMachine mStateMachine;
    private MoveState move;

    private void Start()
    {
        //Get the components of each beahaviour(state) of the turtle and set the onChangeState callback
        move = GetComponent<MoveState>();
        move._onChangeState = OnChangeState;

        //Add the states to the state machine
        mStateMachine.AddState(move);
    }

    public void OnChangeState(Node nextState)
    {
        var nodeComponentsVector = GetComponents<Node>();
        List<Node> components = new List<Node>(nodeComponentsVector);

        components.ForEach(x => x.enabled = false);

        components.FirstOrDefault(x => x.GetType() == nextState.GetType()).enabled = true;
    }
}
