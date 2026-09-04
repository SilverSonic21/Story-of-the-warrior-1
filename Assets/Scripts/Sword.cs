using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Sword : MonoBehaviour
{

    public Animator swordSwing;
    public Sword sword;
    public float damage = 6f;
    public float attackSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(SwingSword());
        }
    }

    IEnumerator SwingSword()
    {
        swordSwing.SetBool("Sword", true);
        yield return new WaitForSeconds(1f / attackSpeed);
        swordSwing.SetBool("Sword", false);
    }
  
}
