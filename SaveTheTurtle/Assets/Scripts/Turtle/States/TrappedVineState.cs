using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrappedVineState : Node
{

    private Life mLife;
    private Rigidbody2D mBody;

    void Start()
    {
        mLife = GetComponent<Life>();
        mBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        mBody.velocity = Vector3.zero;
        InvokeRepeating("ApplyVineDamage", 0, 2.5f);
    }

    private void OnDisable()
    {
        CancelInvoke();
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
