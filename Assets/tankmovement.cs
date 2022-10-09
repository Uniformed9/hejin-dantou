using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankmovement : EnemyParent
{
    // Start is called before the first frame update


    // Update is called once per frame
    float timer = 0.0f;
    float shoot_interval = 5.0f;
    
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        //移动代码
        
            if (distance_flag() < 0 && distance_flag() > -20)
            {
                
                timer += Time.deltaTime;
                if (timer > shoot_interval)
                {
                    timer = 0.0f;
                    enemylaunch();
                }

            }
            else if (distance_flag() > 0 && distance_flag() < 20)
            {
                
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


        //if (collision.transform.name == "explosion(Clone)")
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
    }
    public override void enemylaunch()
    {
        animator.SetTrigger("launch");
        Vector3 offset;
        Vector2 direction;
        if (distance_flag() < 0)
        {
            offset = new Vector3(-1.5f, 2f, 0);
            direction = new Vector2(-1.0f, 0);
        }
        else
        {
            offset = new Vector3(1.5f, 2.0f, 0);
            direction = new Vector2(1.0f, 0);
        }

        //发射子弹
        GameObject projectileObject = Instantiate(projectilePrefab, this.transform.position + offset, Quaternion.identity);
        Projectile x = projectileObject.GetComponent<Projectile>();
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
