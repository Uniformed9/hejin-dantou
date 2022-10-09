using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public int Score;
    public int health = 3;

    //获取其它脚本
    public GameManager gameManager;
    public Character_Controller characterController;
    public score []score_script;
    void Start()    
    {
        Resolution[] resolutions = Screen.resolutions;//获取设置当前屏幕分辩率
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        //找到最大分辨率
        int width = resolutions[0].width, height = resolutions[0].height;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width > width)
            {
                width = resolutions[i].width;
                height = resolutions[i].height;
            }
            if (resolutions[i].width == width && height > resolutions[i].height)
            {
                width = resolutions[i].width;
                height = resolutions[i].height;
            }
        }


        Screen.SetResolution(width, height, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changescore(int a)
    {
        Score=a+Score;
        int count = 0;
        int calculate = Score;
        while (count <= 8)
        {
            
            
            int index=calculate%10;
            calculate /= 10;
            score_script[count].changenumber(index);
            count++;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            health = -1;
            characterController.dead();
            
        }
    }
}
