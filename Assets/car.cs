using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{   public Character_Controller characterController;
    public battery battery;
    bool start = false;
    Rigidbody2D rb;
    bool inside=false;
    bool initialization=true;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            rb.velocity=new Vector2 (5F,0);
            characterController.offset = 5.0f;
            start = false;

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inside) {
                start = true;
            }
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        inside=true;
        if (initialization)
        {
            if (collision.CompareTag("stop"))
            {
                rb.velocity = new Vector2(0F, 0);
                characterController.offset = 0;
                battery.isplaying = false;
                characterController.rigidbody2d.velocity = new Vector2(0, 0);
                characterController.animator.enabled = true;
                characterController.isFree = true;
                initialization = false;
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inside= false;
    }
}
