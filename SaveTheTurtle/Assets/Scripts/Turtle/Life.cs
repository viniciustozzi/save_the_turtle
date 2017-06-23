using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    private GameManager mGameManager;

    private int totalLife;

    public int CurrentLife { get; set; }
    public Action _OnTakeDamage { get; set; }
    public bool IsDefending { get; set; }

    private void Start()
    {
        totalLife = 5;
        CurrentLife = totalLife;

        mGameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int damage)
    {
        if (IsDefending)
            return;

        CurrentLife -= damage;

        if (_OnTakeDamage != null)
            _OnTakeDamage.Invoke();

        if (CurrentLife <= 0)
        {
            mGameManager.OnPlayerDeath();
        }
    }
}
