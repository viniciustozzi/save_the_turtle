using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Life))]
public class DamageController : MonoBehaviour
{
    private Life mLife;

    private void Start()
    {
        mLife = GetComponent<Life>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Damage")
        {
            mLife.TakeDamage(1);
        }
    }
}
