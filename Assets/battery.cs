using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battery : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject projectile;
    int index;
    public Character_Controller characterController;
    SpriteRenderer spriteRenderer;
    public bool isplaying = false;
    bool inside;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inside)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isplaying)
                {
                    
                    isplaying = true;
                    characterController.animator.enabled = false;
                    characterController.spriteRenderer.sprite = characterController.sprites[0];
                    characterController.isFree = false;
                }
                else
                {   //脱离控制状态
                    isplaying = false;
                    characterController.spriteRenderer.flipX = false;
                    characterController.animator.enabled=true;
                    characterController.isFree=true;
                }
            }
        }
      
        if (isplaying)
        {   
            characterController.rigidbody2d.velocity = new Vector2(5.0f, 0);
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (index >= -8)
                {
                   //移动的代码
                    index--;
                    changesprite();
                }
               
               

            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                //Vector2 create = new Vector2(2.5f, 0);
                //create = Quaternion.Euler(0, 0, -10 * index) * create;
                //create.x += transform.position.x;
                //create.y += transform.position.y;
                //Instantiate(projectile, create, Quaternion.identity);

                Vector2 test;
                Vector2 lookdrection=new Vector2(Mathf.Cos((90 - index * 10) * Mathf.PI / 180), Mathf.Sin((90 - index * 10) * Mathf.PI / 180));

                test.x = transform.position.x+2f*lookdrection.x;
                test.y = transform.position.y+0.5f+2f*lookdrection.y;
                GameObject projectileObject=Instantiate(projectile, test, Quaternion.identity);
                Projectile projectileit = projectileObject.GetComponent<Projectile>();
                projectileit.Launch_projectile(lookdrection, 1000f);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (index <= 8)
                {
                    index++;
                    changesprite();
                }
                
            }
        }
        

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        inside = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inside = false;
    }
    void changesprite()
    {
        if (index < 0)
        {
            spriteRenderer.flipX = true;
            spriteRenderer.sprite = sprites[-index];
            //人物
            characterController.spriteRenderer.sprite = characterController.sprites[-index];
            characterController.spriteRenderer.flipX = false;
        }
        else if (index>=0)
        {   spriteRenderer.flipX = false;   
            spriteRenderer.sprite = sprites[index];
            //人物
            characterController.spriteRenderer.sprite = characterController.sprites[index];
            characterController.spriteRenderer.flipX = true;
        }
       
    }
}
