using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrappedVineState : Node
{

    public Life mLife;
    public Rigidbody2D mBody;
    public Animator mAnim;

    private GameObject lastVineTouched;

    private void OnEnable()
    {
        mAnim.SetBool(AnimParams.IsVineTrapped, true);
        mBody.velocity = Vector3.zero;
        InvokeRepeating("ApplyVineDamage", 0, 2.5f);
    }

    private void OnDisable()
    {
        mAnim.SetBool(AnimParams.IsVineTrapped, false);

        CancelInvoke();

        lastVineTouched.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == Tags.VineTrap)
            lastVineTouched = collision.gameObject;
    }

    public void ApplyVineDamage()
    {
        mLife.TakeDamage(1);
    }

    public void ApplyCutDraw()
    {
        _onChangeState.Invoke(Transition.CutVinePlant);
    }

}
