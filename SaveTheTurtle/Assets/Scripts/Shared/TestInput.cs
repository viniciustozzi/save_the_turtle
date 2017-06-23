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
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //    mTurtle.ApplyDraw(DrawType.Box);
        //else if (Input.GetKeyDown(KeyCode.Alpha2))
        //    mTurtle.ApplyDraw(DrawType.CutVine);
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //    mTurtle.ApplyDraw(DrawType.Stair);
    }
}
