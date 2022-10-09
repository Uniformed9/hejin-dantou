using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane :EnemyParent
{
    // Start is called before the first frame update
    Rigidbody2D body;
    float timer = 0.0f;
    float shoot_interval = 4f;
    // Update is called once per frame
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();   
    }
    void Update()
    {
        if (distance_flag() < 5 && distance_flag() > -5)
        {
            body.velocity = new Vector2(4.5f, 0);
            timer += Time.deltaTime;
            if (timer > shoot_interval)
            {
                timer = 0.0f;
                enemylaunch();
            }
        }
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {

        gameSettings.changescore(200);
        health -= 20;//
        
        if (health <= 0)
        {
            enemydead();

        }

    }
    public override void enemylaunch()
    {
        
        
        Vector2 direction=new Vector2(distance_flag(), characterController.position_y() - this.transform.position.y);
        

        //???????
        GameObject projectileObject = Instantiate(projectilePrefab, this.transform.position , Quaternion.identity);
        Projectile x = projectileObject.GetComponent<Projectile>();
        x.Launch_projectile(direction, 10f);
    }
    void enemydead()
    {
        animator.SetTrigger("IsDead");
        
    }

    public void destroy_object()
    {
        Destroy(gameObject);
    }
   
}
