using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class ShieldBlock : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                StartCoroutine(Block());
            }
        }

        
    }
    IEnumerator Block()
        {
            animator.SetBool("Block", true);
            yield return new WaitForSeconds(0.2f);
            animator.SetBool("Block", false);
        }
}
