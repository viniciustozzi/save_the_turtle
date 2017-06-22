using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurtleBehaviour : MonoBehaviour
{
    public MoveState mMove;
    public DefendState mDefend;
    public TrappedVineState mVineTrapped;
    public FallingState mFalling;
    public ClimbingLadderState mLadder;

    private StateMachine mStateMachine;
    private Life mLife;

    private void Start()
    {
        mLife = GetComponent<Life>();

        //Get the components of each beahaviour(state) of the turtle and set the onChangeState callback and the edges
        mMove = GetComponent<MoveState>();
        mMove._onChangeState = OnChangeState;
            
        mFalling = GetComponent<FallingState>();
        mFalling._onChangeState = OnChangeState;

        mVineTrapped = GetComponent<TrappedVineState>();
        mVineTrapped._onChangeState = OnChangeState;

        mLadder = GetComponent<ClimbingLadderState>();
        mLadder._onChangeState = OnChangeState;

        //Add the states to the state machine
        mStateMachine = new StateMachine();

        mStateMachine.AddState(mMove, new List<Edge>()
        {
            new Edge(mMove, Transition.NotGrounded, mFalling),
            new Edge(mMove, Transition.FindLadder, mLadder),
            new Edge(mMove, Transition.VineTrapped, mVineTrapped)
        });

        mStateMachine.AddState(mFalling, new List<Edge>()
        {
            new Edge(mFalling, Transition.Grounded, mMove),
            new Edge(mFalling, Transition.VineTrapped, mVineTrapped)
         });

        mStateMachine.AddState(mVineTrapped, new List<Edge>()
        {
            new Edge(mVineTrapped, Transition.CutVinePlant, mMove)
        });

        mStateMachine.AddState(mLadder, new List<Edge>()
        {
            new Edge(mLadder, Transition.ExitLadder, mMove)
        });

        //mDefend = GetComponent<DefendState>();
        //mDefend._onChangeState = OnChangeState;

        //mStateMachine.AddState(mDefend, new List<Edge>()
        //{

        //});
    }

    public void OnChangeState(Transition t)
    {
        mStateMachine.OnChangeState(t);
    }

    public void ApplyDraw(DrawType draw)
    {
        switch (draw)
        {
            case DrawType.Box:
                break;
            case DrawType.CutVine:
                mVineTrapped.ApplyCutDraw();
                break;
        }
    }
}
