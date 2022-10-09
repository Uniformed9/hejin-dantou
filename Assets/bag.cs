using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bag : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    public Sprite[] a;
    public GameSettings settings;
    public int health;
    int index = 0;
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
        if (character != null)
        {
            index++;
            settings.changescore(100);
            if (index == 5)
            {
                spriteRenderer.sprite = a[0];
            }
            if(index == 10)
            {
                Destroy(gameObject);
            }

        }
    }
}
