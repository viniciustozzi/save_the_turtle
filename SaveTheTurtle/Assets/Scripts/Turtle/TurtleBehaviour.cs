using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MoveState))]
[RequireComponent(typeof(DefendState))]
[RequireComponent(typeof(Life))]
public class TurtleBehaviour : MonoBehaviour
{
    private StateMachine mStateMachine;
    private MoveState mMove;
    private DefendState mDefend;
    private Life mLife;

    private void Start()
    {
        mLife = GetComponent<Life>();

        //Get the components of each beahaviour(state) of the turtle and set the onChangeState callback and the edges
        mMove = GetComponent<MoveState>();
        mMove._onChangeState = OnChangeState;

        mDefend = GetComponent<DefendState>();
        mDefend._onChangeState = OnChangeState;

        //Add the states to the state machine
        mStateMachine = new StateMachine();
        mStateMachine.AddState(mMove, new List<Edge>()
        {
            new Edge(Transition.OnFloor, mDefend)
        });
       
    }

    public void OnChangeState(Transition t)
    {
        mStateMachine.OnChangeState(t);
    }
}
