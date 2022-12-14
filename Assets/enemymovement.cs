using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : EnemyParent
{   
   
    float timer=0.0f;
    float shoot_interval=2.5f;
    Rigidbody rb;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {

        //�ƶ�����
       
            if (distance_flag() < 0 && distance_flag() > -15)
            {
                animator.SetFloat("look", 0);
                timer += Time.deltaTime;
                if (timer > shoot_interval)
                {
                    timer = 0.0f;
                    enemylaunch();
                }

            }
            else if (distance_flag() > 0 && distance_flag() < 10)
            {
                animator.SetFloat("look", 1);
                timer += Time.deltaTime;
                if (timer > shoot_interval)
                {
                    timer = 0.0f;
                    enemylaunch();
                }
            }
       
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Projectile projectile = collision.collider.GetComponent<Projectile>();
        if (projectile != null)
        {

            gameSettings.changescore(100);
            health -= projectile.damage;
            if (health < 0)
            {
                enemydead();

            }
        }

    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        //if (collision.transform.name== "explosion(Clone)")
        //{
            
        //    gameSettings.changescore(200);
        //    health -= 20;//
        //    if (health <= 0)
        //    {
        //        enemydead();
                
        //    }
        //}
        gameSettings.changescore(200);
        health -= 20;//
        if (health <= 0)
        {
            enemydead();

        }
        //Projectile projectile = collision.GetComponent<Collider>().GetComponent<Projectile>();
        //if (projectile != null)
        //{

        //    gameSettings.changescore(100);
        //    health -= projectile.damage;
        //    if (health < 0)
        //    {
        //        enemydead();
        //        deaded = true;
        //    }
        //}

    }
    public override void enemylaunch()
    {   
        animator.SetTrigger("launch");
        Vector3 offset;
        Vector2 direction;
        if (distance_flag() < 0)
        {
             offset= new Vector3(-1.5f, 0,0);
            direction = new Vector2(-1.0f, 0);
        }
        else
        {
            offset = new Vector3(1.5f, 0, 0);
            direction = new Vector2(1.0f, 0);
        }

        //�����ӵ�
        GameObject projectileObject = Instantiate(projectilePrefab, this.transform.position +offset , Quaternion.identity);
        Projectile x=projectileObject.GetComponent<Projectile>();
        x.Launch_projectile(direction, 80f);
    }
    void enemydead()
    {
        animator.SetTrigger("Isdead");
    }
    public void destroy_object()
    {
        Destroy(gameObject);
    }
}
