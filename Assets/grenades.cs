using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenades : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody2d;
    
    public GameObject explodsion;
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
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Character_Controller e = other.collider.GetComponent<Character_Controller>();
        //if (e != null)
        //{

        //}
        Vector2 explode = new Vector2(rigidbody2d.position.x,rigidbody2d.position .y);
        GameObject explosionObject = Instantiate(explodsion, explode, Quaternion.identity);
        Destroy(gameObject);
    }
    public void Launch_projectile(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
}
