using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldman : MonoBehaviour
{
    public Character_Controller characterController;
    public GameSettings gameSettings;
    BoxCollider2D co2D;
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    bool IsOut;
    float timer;
    float timing=2f;
    float flag=-0.5f;
    float timeranother;
    bool start = false;
    bool Isbeginrun = false;
    bool anime=false;
    float animetimer = 0;
 
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        co2D = GetComponent<BoxCollider2D>(); 
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timeranother += Time.deltaTime;
            if (timeranother > 1.8f)
            {
                start = false;
                Isbeginrun = true;
            }
        }

        if (Isbeginrun)
        {
            if (IsOut)
            {

                timer += Time.deltaTime;
                if (timer > timing)
                {
                    flag *= -1;
                    timer = 0;

                }
                animator.SetFloat("look", 0.5f + flag);
                rb.velocity = new Vector2(4.0f * flag, 0);
            }
        }
        //
        if (IsOut)
        {
            if (distance_flag() < 1 && distance_flag() > -1)
            {
                animator.SetTrigger("IsSafe");

                IsOut = false;
                rb.velocity = new Vector2(0, 0);
                anime = true;
            }
        }
       
        if (anime)
        {
            animetimer += Time.deltaTime;
            if (animetimer > 1.5f)
            {
                gameSettings.changescore(1000);
                Destroy(gameObject);
            }
        }
       

        //
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {   Projectile projectile = collision.collider.GetComponent<Projectile>();
        if(projectile != null)
        {
            GetComponent<Collider2D>().isTrigger = true;
            animator.SetBool("IsOut",true);
            IsOut = true;
            start=true;
        }
       
    }

    protected float distance_flag()
    {   

        float distance = characterController.position() - this.transform.position.x;
        return distance;
    }
}
