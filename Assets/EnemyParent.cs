using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    // Start is called before the first frame update
    public Character_Controller characterController;
    public GameObject projectilePrefab;
    public GameSettings gameSettings;
    protected Animator animator;
    public int health ;
    // Start is called before the first frame update
    protected void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (distance_flag() < 0 && distance_flag() > -5)
        {
            enemylaunch();
        }
        else if (distance_flag() > 0 && distance_flag() < 5)
        {
            enemylaunch();
        }
    }
    protected float distance_flag()
    {
        float distance = characterController.position() - this.transform.position.x;
        return distance;
    }
   
    public virtual  void enemylaunch()//ÿ�����˶��е��������
    {
       
    }
}
