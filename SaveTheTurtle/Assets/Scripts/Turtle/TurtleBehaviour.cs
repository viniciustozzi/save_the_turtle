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
    public OnBoatState mBoat;

    private StateMachine mStateMachine;
    //private Life mLife;

    private void Start()
    {
        //Set the callback for state change
        mMove._onChangeState = OnChangeState;
        mFalling._onChangeState = OnChangeState;
        mVineTrapped._onChangeState = OnChangeState;
        mLadder._onChangeState = OnChangeState;
        mBoat._onChangeState = OnChangeState;

        //Add the states to the state machine
        mStateMachine = new StateMachine();

        mStateMachine.AddState(mMove, new List<Edge>()
        {
            new Edge(mMove, Transition.NotGrounded, mFalling),
            new Edge(mMove, Transition.FindLadder, mLadder),
            new Edge(mMove, Transition.VineTrapped, mVineTrapped),
            new Edge(mMove, Transition.EnterBoat, mBoat)
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

        mStateMachine.AddState(mBoat, new List<Edge>()
        {
            new Edge(mBoat, Transition.ExitBoat, mMove)
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
