using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class SwordHitbox : MonoBehaviour
{
    public float damage = 6f;
    private bool canHit = false;

    public void EnableHitbox()
    {
        canHit = true;
    }

    public void DisableHitbox()
    {
        canHit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canHit) return;

        
        WallDamage wall = other.GetComponent<WallDamage>();
        if (wall != null)
        {
            wall.TakeDamage(damage);
            return;
        }

        
        SwordGuy enemy = other.GetComponent<SwordGuy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            return;
        }
    }
}

