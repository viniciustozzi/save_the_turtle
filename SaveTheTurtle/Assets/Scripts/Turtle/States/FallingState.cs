using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : Node
{
    private Animator mAnim;

    private void Start()
    {
        mAnim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        //TODO: Tocar animação da tartaruga caindo
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == Tags.Ground)
            _onChangeState.Invoke(Transition.OnFloor);

        if (collision.transform.tag == Tags.VineTrap)
            _onChangeState.Invoke(Transition.VineTrapped);
    }
}
