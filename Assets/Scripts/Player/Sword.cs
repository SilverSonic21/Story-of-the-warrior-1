using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Sword : MonoBehaviour
{

    public Animator swordSwing;

    public float attackSpeed = 2f;
    
    public SwordHitbox hitbox;

void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(SwingSword());
        }
    }

    IEnumerator SwingSword()
    {
        swordSwing.SetBool("Sword", true);
        hitbox.EnableHitbox();
        yield return new WaitForSeconds(1f / attackSpeed);
        hitbox.DisableHitbox();
        swordSwing.SetBool("Sword", false);
    }
  
}
