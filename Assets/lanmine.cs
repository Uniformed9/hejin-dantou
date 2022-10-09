using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanmine : MonoBehaviour
{   Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();    
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Projectile projectile = collision.GetComponent<Projectile>();
        if(projectile != null)
        {
            animator.SetTrigger("encounter");
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Projectile projectile = collision.collider.GetComponent<Projectile>();
        if (projectile != null)
        {
            animator.SetTrigger("encounter");
        }
        CharacterController characterController=collision.collider.GetComponent<CharacterController>();
        if(characterController != null)
        {
            animator.SetTrigger("encounter");
        }
    }
}
