using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{

    private GameManager mGameManager;

    private void Start()
    {
        mGameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == Tags.Player)
        {
            mGameManager.OnVictory();
        }
    }
}
