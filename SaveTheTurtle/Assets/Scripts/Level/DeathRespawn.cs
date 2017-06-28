using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRespawn : MonoBehaviour
{
    public Transform respawn;

    private Transform mTurtle;
    private Rigidbody2D turtleBody;

    private void Start()
    {
        mTurtle = FindObjectOfType<TurtleBehaviour>().transform;
        turtleBody = mTurtle.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.transform.tag == Tags.Player)
        {
            mTurtle.position = respawn.position;
            turtleBody.angularVelocity = 0;
            mTurtle.rotation = Quaternion.identity;
        }
    }

}
