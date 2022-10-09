using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Character_Controller : MonoBehaviour
{
    public int health;
    public float speed = 3.0f;
    public float upForce = 10000.0f;

    //需要拖动的变量
    public GameSettings gameSettings;
    public GameObject projectilePrefab;
    public healthnumber gameHealth;
    public BoxCollider2D boxcollider2D;
    public GameObject grenadesPrefab;
    public GameObject close_attack;
    //
    
    float invincibletime = 1.8f;
    float timer = 0.0f;
    bool IsInvincible = false;
    bool timerflag = false;

    public Animator animator;
    public Rigidbody2D rigidbody2d;
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    float horizontal;
    Vector2 lookdrection = new Vector2(-1.0F, 0F);
    public float offset;
    bool IsGround;
    public bool isFree =true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();
        
        boxcollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFree)
        {
            if (!IsInvincible)
            {
                horizontal = Input.GetAxis("Horizontal");
                rigidbody2d.velocity = new Vector2(horizontal * speed + offset, rigidbody2d.velocity.y);
                //走的动画
                if (horizontal > 0)
                {
                    animator.SetFloat("look", 1);
                    lookdrection.x = 1.0f;
                }
                if (horizontal < 0)
                {
                    animator.SetFloat("look", 0);
                    lookdrection.x = -1f;
                }
            }
            else
            {
                rigidbody2d.velocity = new Vector2( offset, 0);
            }
            //animator.SetFloat("look", horizontal);
            //走到跑的动画
            if (Mathf.Approximately(horizontal, 0.0f))
            {
                animator.SetBool("IsRunning", false);

            }
            else
            {
                animator.SetBool("IsRunning", true);

            }
            //
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("IsUp", true);
            }
            else
            {
                animator.SetBool("IsUp", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("IsDown", true);
                boxcollider2D.size = new Vector2(0.5f, 0.4f);
            }
            else
            {
                animator.SetBool("IsDown", false);
                boxcollider2D.size = new Vector2(0.5f, 0.7f);
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                Vector2 raycast = new Vector2(rigidbody2d.position.x, rigidbody2d.position.y + 1.0f);
                RaycastHit2D hit = Physics2D.Raycast(raycast, Vector2.right, 3f);
                if (hit.collider != null)
                {

                    if (hit.collider.gameObject.CompareTag("Enemy"))
                    {

                        animator.SetTrigger("close_attack");
                        Vector2 closeattack = new Vector2(raycast.x + lookdrection.x * 2, raycast.y);
                        GameObject attackclose = Instantiate(close_attack, closeattack, Quaternion.identity);
                        //手刀
                    }
                    else
                    {
                        Launch();
                    }
                }
                else
                {
                    Launch();
                }
            }
            Vector2 groundcast = new Vector2(rigidbody2d.position.x, rigidbody2d.position.y+1);
            RaycastHit2D Groundcast = Physics2D.Raycast(groundcast, Vector2.down, 1.1f);
            
            if (Groundcast.collider != null)
            {
                
                if (Input.GetKeyDown(KeyCode.K))
                {
                    animator.SetBool("Jump", true);
                    rigidbody2d.velocity = new Vector2(horizontal * speed + offset, 15.0f);
                    //rigidbody2d.AddForce(Vector2.up * upForce);
                }

                
            }
            
            if (Input.GetKeyDown(KeyCode.L))
            {
                throw_grenades();
            }

        }
       
        //无敌计时器
        if (timerflag)
        {
            timer += Time.deltaTime;
            if (timer > invincibletime)
            {
                timerflag = false;
                IsInvincible = false;
            }
        }


    }
    void throw_grenades()
    {
        Vector2 vector2 = rigidbody2d.position;
        vector2.y += 1.5f;

        GameObject projectileObject = Instantiate(grenadesPrefab, vector2 + lookdrection * 2, Quaternion.identity);

        grenades projectile = projectileObject.GetComponent<grenades>();
        Vector2 grenades = new Vector2(lookdrection.x, 2.0f);
        projectile.Launch_projectile(grenades, 175f);

        animator.SetTrigger("Throw");
    }

    void Launch()
    {
        if (animator.GetBool("IsUp"))
        {//向上打

            GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 4, Quaternion.identity);
            projectileObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            Projectile projectile = projectileObject.GetComponent<Projectile>();
            projectile.Launch_projectile(Vector2.up, 1000f);

            animator.SetTrigger("Launch");
        }
        else if (animator.GetBool("IsDown") && rigidbody2d.velocity.y != 0)
        {//向下打

        }
        else
        {
            Vector2 vector2 = rigidbody2d.position;
            vector2.y += 1.5f;

            GameObject projectileObject = Instantiate(projectilePrefab, vector2 + lookdrection * 2, Quaternion.identity);

            Projectile projectile = projectileObject.GetComponent<Projectile>();
            projectile.Launch_projectile(lookdrection, 1000f);


            animator.SetTrigger("Launch");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("Jump", false);
        Projectile projectile = collision.collider.GetComponent<Projectile>();

        if (projectile != null)
        {
            if (!IsInvincible)
            {
                dead();
                timerflag = true;
                IsInvincible = true;
    
            }
            //死亡函数

        }
    }
    public float position()
    {
        return rigidbody2d.position.x;
    }
    public float position_y()
    {
        return rigidbody2d.position.y;
    }
    public void dead()
    {
        if (gameSettings.health > 0)
        {
            gameSettings.health--;
            //数字减一
            gameHealth.changenumber(gameSettings.health);
            isFree = true;
            animator.SetTrigger("Isdead");
        } else
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().param = gameSettings.Score;
            SceneManager.LoadScene("final");
        }
        
    }
   
}
