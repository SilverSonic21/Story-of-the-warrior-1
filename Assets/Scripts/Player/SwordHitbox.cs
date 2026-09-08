using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class SwordHitbox : MonoBehaviour
{
    public float damage = 6f;
    private bool canDamage = false;

    public void EnableHitbox()
    {
        canDamage = true;
    }

    public void DisableHitbox()
    {
        canDamage = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canDamage) return;

        SwordGuy enemy = other.GetComponent<SwordGuy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}

