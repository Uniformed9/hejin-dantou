using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 positon_ = new Vector2(0.0F, 0.0F);
    Rigidbody2D rb;
    Rigidbody2D here;
    float min;
    void Start()
    {   rb= GameObject.Find("character").GetComponent<Rigidbody2D>();
        here = GetComponent<Rigidbody2D>();
        min = rb.position.x;
    }

    // Update is called once per frame
    void Update()
    {   
        if (rb.position.x >= min)
        {
            positon_.x = rb.position.x;
            here.position = positon_;
            min = rb.position.x;
        }
        
    }
}
