using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingLadderState : Node
{
    public Animator mAnim;

    public Transform StairStep1;
    public Transform StairStep2;
    public Transform StairStep3;
    public Transform StairStep4;
    public Transform StairStep5;

    private void Start()
    {
        mAnim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOMove(StairStep1.position, 0.3f))
            .Append(transform.DOMove(StairStep2.position, 0.2f))
            .Append(transform.DOMove(StairStep3.position, 0.2f))
            .Append(transform.DOMove(StairStep4.position, 0.2f))
            .Append(transform.DOMove(StairStep5.position, 0.2f))
            .AppendCallback(EndLadderAnimation);

    }

    public void EndLadderAnimation()
    {
        _onChangeState.Invoke(Transition.ExitLadder);
    }

}
