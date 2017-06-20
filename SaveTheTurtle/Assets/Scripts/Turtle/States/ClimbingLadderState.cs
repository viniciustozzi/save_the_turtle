using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingLadderState : Node
{
    private Animator mAnim;

    private void Start()
    {
        mAnim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        //TODO: Começa animação loca da tartaruga subindo escada


    }

    public void EndLadderAnimation()
    {
        _onChangeState.Invoke(Transition.ExitLadder);
    }

}
