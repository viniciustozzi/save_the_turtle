using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    private TurtleBehaviour mTurtle;

    private void Start()
    {
        mTurtle = FindObjectOfType<TurtleBehaviour>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            mTurtle.ApplyDraw(DrawType.Box);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            mTurtle.ApplyDraw(DrawType.Plank);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            mTurtle.ApplyDraw(DrawType.Stair);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            mTurtle.ApplyDraw(DrawType.Boat);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            mTurtle.ApplyDraw(DrawType.X);
    }
}
