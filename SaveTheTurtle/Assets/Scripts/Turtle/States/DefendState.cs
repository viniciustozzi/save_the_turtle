using UnityEngine;

[RequireComponent(typeof(Life))]
[RequireComponent(typeof(Rigidbody2D))]
public class DefendState : Node
{
    public Life mLife;
    public Rigidbody2D mBody;

    private void Start()
    {
        mLife = GetComponent<Life>();
        mBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        mBody.velocity = Vector3.zero;
        mLife.IsDefending = true;
    }

    private void OnDisable()
    {
        mLife.IsDefending = false;
    }
}
