using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveState : Node
{

    public float speed;

    private Rigidbody2D mBody;
    
    private void Start()
    {
        mBody = GetComponent<Rigidbody2D>();
    }

    public override void SetupEdges()
    {
           
    }

    private void FixedUpdate()
    {
        mBody.velocity = new Vector2(speed, mBody.velocity.y);
    }
}
