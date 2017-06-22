using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveState : Node
{
    public float speed;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Rigidbody2D mBody;

    private void Start()
    {
        mBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        mBody.velocity = new Vector2(speed, mBody.velocity.y);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == Tags.Ground)
            _onChangeState.Invoke(Transition.NotGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == Tags.Ladder)
            _onChangeState.Invoke(Transition.FindLadder);
        else if (collision.transform.tag == Tags.VineTrap)
            _onChangeState.Invoke(Transition.VineTrapped);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == Tags.Stair)
            _onChangeState.Invoke(Transition.FindLadder);
    }
}
