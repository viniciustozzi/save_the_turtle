using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrappedVineState : Node
{

    private Life mLife;
    private Rigidbody2D mBody;
    private Animator mAnim;

    void Start()
    {
        mLife = GetComponent<Life>();
        mBody = GetComponent<Rigidbody2D>();
        mAnim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        //TODO: Criar classe para os nomes do parametro do animator e verificar pq rigidbody está nulo
        //mAnim.SetBool("")
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
