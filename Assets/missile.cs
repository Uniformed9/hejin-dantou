using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{   Rigidbody2D rb;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        animator.SetBool("IsDead",true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.isKinematic = false;
        animator.SetBool("IsDown", true);
    }
}
