﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int totalLife;

    public int CurrentLife { get; set; }
    public Action _OnTakeDamage { get; set; }
    public bool IsDefending { get; set; }

    private void Awake()
    {
        CurrentLife = totalLife;
    }

    public void TakeDamage(int damage)
    {
        if (IsDefending)
            return;

        CurrentLife -= damage;

        if (_OnTakeDamage != null)
            _OnTakeDamage.Invoke();
    }
}
