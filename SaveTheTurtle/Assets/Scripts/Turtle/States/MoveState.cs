using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveState : Node
{
    public float speed;
    public LayerMask groundLayer;
    public Rigidbody2D mBody;
    public Transform groundCheck;

    private void Start()
    {
        mBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        mBody.velocity = new Vector2(speed, mBody.velocity.y);
    }

    void Update()
    {
        if (!IsGrounded())
        {
            _onChangeState.Invoke(Transition.NotGrounded);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.Raycast(groundCheck.position, -Vector2.up, 3f, groundLayer);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        //if (collision.transform.tag == Tags.Ground)
        //    _onChangeState.Invoke(Transition.NotGrounded);
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

        if (collider.tag == Tags.Boat)
            _onChangeState.Invoke(Transition.EnterBoat);
    }
}
