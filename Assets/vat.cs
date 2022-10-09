using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vat : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite []a;
    public GameSettings settings;
    int index = 0;
    public int health=30;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Projectile character = other.collider.GetComponent<Projectile>();
        if (character!=null)
        {
            if (index <= 1)
            {
                spriteRenderer.sprite = a[index];
                index++;
                settings.changescore(50);
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }
}
