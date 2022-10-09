using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_sky : EnemyParent
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
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
