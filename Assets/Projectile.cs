using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
     public int damage;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Character_Controller e = other.collider.GetComponent<Character_Controller>();
        //if (e != null)
        //{

        //}
        if (!transform.CompareTag("landmine"))
        {
            Destroy(gameObject);
        }   
        
    
        
    }
    public void Launch_projectile(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    public void destroy_object()
    {
        Destroy(gameObject);
    }
}