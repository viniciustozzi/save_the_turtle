using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : Node
{
    public Animator mAnim;

    private void OnEnable()
    {
        mAnim.SetBool(AnimParams.IsFalling, true);
    }

    private void OnDisable()
    {
        mAnim.SetBool(AnimParams.IsFalling, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == Tags.Ground)
            _onChangeState.Invoke(Transition.OnFloor);

        if (collision.transform.tag == Tags.VineTrap)
            _onChangeState.Invoke(Transition.VineTrapped);
    }
}
